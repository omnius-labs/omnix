namespace Omnius.Core.Network.Connections
{
    public class BaseConnectionOptions
    {
        public int MaxReceiveByteCount { get; init; } = 1024 * 64;

        public IBytesPool? BytesPool { get; init; }
    }
}
