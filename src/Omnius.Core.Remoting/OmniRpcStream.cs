using System;
using System.Buffers;
using System.Threading;
using System.Threading.Tasks;
using Omnius.Core;
using Omnius.Core.Network.Connections;
using Omnius.Core.Serialization.RocketPack;

namespace Omnius.Core.Remoting
{
    public sealed partial class OmniRpcStream : DisposableBase
    {
        private readonly IConnection _connection;
        private readonly IBufferPool<byte> _bufferPool;

        internal OmniRpcStream(IConnection connection, IBufferPool<byte> bufferPool)
        {
            _connection = connection;
            _bufferPool = bufferPool;
        }

        private enum PacketType : byte
        {
            Message = 0,
            ErrorMessage = 1,
            Canceled = 2,
            Completed = 3,
        }

        public async ValueTask SendMessageAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
            where TMessage : IRocketPackMessage<TMessage>
        {
            await _connection.SendAsync((bufferWriter) =>
            {
                bufferWriter.GetSpan(1)[0] = (byte)PacketType.Message;
                bufferWriter.Advance(1);
                var writer = new RocketPackWriter(bufferWriter, _bufferPool);
                IRocketPackMessage<TMessage>.Formatter.Serialize(ref writer, message, 0);
            }, cancellationToken);
        }

        public async ValueTask SendErrorMessageAsync(OmniRpcErrorMessage errorMessage, CancellationToken cancellationToken = default)
        {
            await _connection.SendAsync((bufferWriter) =>
            {
                bufferWriter.GetSpan(1)[0] = (byte)PacketType.ErrorMessage;
                bufferWriter.Advance(1);
                errorMessage.Export(bufferWriter, _bufferPool);
            }, cancellationToken);
        }

        public async ValueTask SendCanceledAsync(CancellationToken cancellationToken = default)
        {
            await _connection.SendAsync((bufferWriter) =>
            {
                bufferWriter.GetSpan(1)[0] = (byte)PacketType.Canceled;
                bufferWriter.Advance(1);
            }, cancellationToken);
        }

        public async ValueTask SendCompletedAsync(CancellationToken cancellationToken = default)
        {
            await _connection.SendAsync((bufferWriter) =>
            {
                bufferWriter.GetSpan(1)[0] = (byte)PacketType.Completed;
                bufferWriter.Advance(1);
            }, cancellationToken);
        }

        public async ValueTask<OmniRpcStreamReceiveResult<TMessage>> ReceiveAsync<TMessage>(CancellationToken cancellationToken = default)
            where TMessage : IRocketPackMessage<TMessage>
        {
            OmniRpcStreamReceiveResult<TMessage> receiveResult = default;

            await _connection.ReceiveAsync((sequence) =>
            {
                Span<byte> type = stackalloc byte[1];
                sequence.CopyTo(type);

                switch ((PacketType)type[0])
                {
                    case PacketType.Message:
                        var reader = new RocketPackReader(sequence, _bufferPool);
                        var message = IRocketPackMessage<TMessage>.Formatter.Deserialize(ref reader, 0);
                        receiveResult = new OmniRpcStreamReceiveResult<TMessage>(message, null, false, false);
                        break;
                    case PacketType.ErrorMessage:
                        var errorMessage = OmniRpcErrorMessage.Import(sequence, _bufferPool);
                        receiveResult = new OmniRpcStreamReceiveResult<TMessage>(default, errorMessage, false, false);
                        break;
                    case PacketType.Canceled:
                        receiveResult = new OmniRpcStreamReceiveResult<TMessage>(default, null, true, false);
                        break;
                    case PacketType.Completed:
                        receiveResult = new OmniRpcStreamReceiveResult<TMessage>(default, null, false, true);
                        break;
                }
            }, cancellationToken);

            return receiveResult;
        }

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Dispose();
            }
        }
    }
}