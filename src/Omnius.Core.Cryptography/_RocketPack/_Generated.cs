
#nullable enable

namespace Omnius.Core.Cryptography
{
    public enum OmniHashAlgorithmType : byte
    {
        Unknown = 0,
        Sha2_256 = 1,
    }
    public enum OmniAgreementAlgorithmType : byte
    {
        Unknown = 0,
        EcDh_P521_Sha2_256 = 1,
    }
    public enum OmniDigitalSignatureAlgorithmType : byte
    {
        Unknown = 0,
        EcDsa_P521_Sha2_256 = 1,
    }
    public enum OmniHashcashAlgorithmType : byte
    {
        Unknown = 0,
        Sha2_256 = 1,
    }
    public readonly partial struct OmniHash : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHash>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniHash> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHash>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniHash Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHash>.Empty;

        static OmniHash()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHash>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHash>.Empty = new global::Omnius.Core.Cryptography.OmniHash((OmniHashAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly int ___hashCode;

        public static readonly int MaxValueLength = 256;

        public OmniHash(OmniHashAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> value)
        {
            if (value.Length > 256) throw new global::System.ArgumentOutOfRangeException("value");

            this.AlgorithmType = algorithmType;
            this.Value = value;

            {
                var ___h = new global::System.HashCode();
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!value.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(value.Span));
                ___hashCode = ___h.ToHashCode();
            }
        }

        public OmniHashAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> Value { get; }

        public static global::Omnius.Core.Cryptography.OmniHash Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniHash left, global::Omnius.Core.Cryptography.OmniHash right)
        {
            return right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniHash left, global::Omnius.Core.Cryptography.OmniHash right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniHash)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniHash)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniHash target)
        {
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Value.Span, target.Value.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniHash>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniHash value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                w.Write((ulong)value.AlgorithmType);
                w.Write(value.Value.Span);
            }

            public global::Omnius.Core.Cryptography.OmniHash Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                OmniHashAlgorithmType p_algorithmType = (OmniHashAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_value = global::System.ReadOnlyMemory<byte>.Empty;

                {
                    p_algorithmType = (OmniHashAlgorithmType)r.GetUInt64();
                }
                {
                    p_value = r.GetMemory(256);
                }
                return new global::Omnius.Core.Cryptography.OmniHash(p_algorithmType, p_value);
            }
        }
    }
    public sealed partial class OmniAgreement : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreement>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniAgreement> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreement>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniAgreement Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreement>.Empty;

        static OmniAgreement()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreement>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreement>.Empty = new global::Omnius.Core.Cryptography.OmniAgreement(global::Omnius.Core.RocketPack.Timestamp.Zero, (OmniAgreementAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxPublicKeyLength = 8192;
        public static readonly int MaxPrivateKeyLength = 8192;

        public OmniAgreement(global::Omnius.Core.RocketPack.Timestamp creationTime, OmniAgreementAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> publicKey, global::System.ReadOnlyMemory<byte> privateKey)
        {
            if (publicKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("publicKey");
            if (privateKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("privateKey");

            this.CreationTime = creationTime;
            this.AlgorithmType = algorithmType;
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!publicKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(publicKey.Span));
                if (!privateKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(privateKey.Span));
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.RocketPack.Timestamp CreationTime { get; }
        public OmniAgreementAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> PublicKey { get; }
        public global::System.ReadOnlyMemory<byte> PrivateKey { get; }

        public static global::Omnius.Core.Cryptography.OmniAgreement Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniAgreement? left, global::Omnius.Core.Cryptography.OmniAgreement? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniAgreement? left, global::Omnius.Core.Cryptography.OmniAgreement? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniAgreement)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniAgreement)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniAgreement? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.CreationTime != target.CreationTime) return false;
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PublicKey.Span, target.PublicKey.Span)) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PrivateKey.Span, target.PrivateKey.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniAgreement>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniAgreement value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.CreationTime != global::Omnius.Core.RocketPack.Timestamp.Zero)
                {
                    w.Write((uint)1);
                    w.Write(value.CreationTime);
                }
                if (value.AlgorithmType != (OmniAgreementAlgorithmType)0)
                {
                    w.Write((uint)2);
                    w.Write((ulong)value.AlgorithmType);
                }
                if (!value.PublicKey.IsEmpty)
                {
                    w.Write((uint)3);
                    w.Write(value.PublicKey.Span);
                }
                if (!value.PrivateKey.IsEmpty)
                {
                    w.Write((uint)4);
                    w.Write(value.PrivateKey.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniAgreement Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::Omnius.Core.RocketPack.Timestamp p_creationTime = global::Omnius.Core.RocketPack.Timestamp.Zero;
                OmniAgreementAlgorithmType p_algorithmType = (OmniAgreementAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_publicKey = global::System.ReadOnlyMemory<byte>.Empty;
                global::System.ReadOnlyMemory<byte> p_privateKey = global::System.ReadOnlyMemory<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                        case 2:
                            {
                                p_algorithmType = (OmniAgreementAlgorithmType)r.GetUInt64();
                                break;
                            }
                        case 3:
                            {
                                p_publicKey = r.GetMemory(8192);
                                break;
                            }
                        case 4:
                            {
                                p_privateKey = r.GetMemory(8192);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniAgreement(p_creationTime, p_algorithmType, p_publicKey, p_privateKey);
            }
        }
    }
    public sealed partial class OmniAgreementPublicKey : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPublicKey>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniAgreementPublicKey> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPublicKey>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniAgreementPublicKey Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPublicKey>.Empty;

        static OmniAgreementPublicKey()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPublicKey>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPublicKey>.Empty = new global::Omnius.Core.Cryptography.OmniAgreementPublicKey(global::Omnius.Core.RocketPack.Timestamp.Zero, (OmniAgreementAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxPublicKeyLength = 8192;

        public OmniAgreementPublicKey(global::Omnius.Core.RocketPack.Timestamp creationTime, OmniAgreementAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> publicKey)
        {
            if (publicKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("publicKey");

            this.CreationTime = creationTime;
            this.AlgorithmType = algorithmType;
            this.PublicKey = publicKey;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!publicKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(publicKey.Span));
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.RocketPack.Timestamp CreationTime { get; }
        public OmniAgreementAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> PublicKey { get; }

        public static global::Omnius.Core.Cryptography.OmniAgreementPublicKey Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniAgreementPublicKey? left, global::Omnius.Core.Cryptography.OmniAgreementPublicKey? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniAgreementPublicKey? left, global::Omnius.Core.Cryptography.OmniAgreementPublicKey? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniAgreementPublicKey)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniAgreementPublicKey)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniAgreementPublicKey? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.CreationTime != target.CreationTime) return false;
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PublicKey.Span, target.PublicKey.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniAgreementPublicKey>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniAgreementPublicKey value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.CreationTime != global::Omnius.Core.RocketPack.Timestamp.Zero)
                {
                    w.Write((uint)1);
                    w.Write(value.CreationTime);
                }
                if (value.AlgorithmType != (OmniAgreementAlgorithmType)0)
                {
                    w.Write((uint)2);
                    w.Write((ulong)value.AlgorithmType);
                }
                if (!value.PublicKey.IsEmpty)
                {
                    w.Write((uint)3);
                    w.Write(value.PublicKey.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniAgreementPublicKey Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::Omnius.Core.RocketPack.Timestamp p_creationTime = global::Omnius.Core.RocketPack.Timestamp.Zero;
                OmniAgreementAlgorithmType p_algorithmType = (OmniAgreementAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_publicKey = global::System.ReadOnlyMemory<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                        case 2:
                            {
                                p_algorithmType = (OmniAgreementAlgorithmType)r.GetUInt64();
                                break;
                            }
                        case 3:
                            {
                                p_publicKey = r.GetMemory(8192);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniAgreementPublicKey(p_creationTime, p_algorithmType, p_publicKey);
            }
        }
    }
    public sealed partial class OmniAgreementPrivateKey : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniAgreementPrivateKey Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey>.Empty;

        static OmniAgreementPrivateKey()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey>.Empty = new global::Omnius.Core.Cryptography.OmniAgreementPrivateKey(global::Omnius.Core.RocketPack.Timestamp.Zero, (OmniAgreementAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxPrivateKeyLength = 8192;

        public OmniAgreementPrivateKey(global::Omnius.Core.RocketPack.Timestamp creationTime, OmniAgreementAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> privateKey)
        {
            if (privateKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("privateKey");

            this.CreationTime = creationTime;
            this.AlgorithmType = algorithmType;
            this.PrivateKey = privateKey;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (creationTime != default) ___h.Add(creationTime.GetHashCode());
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!privateKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(privateKey.Span));
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.RocketPack.Timestamp CreationTime { get; }
        public OmniAgreementAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> PrivateKey { get; }

        public static global::Omnius.Core.Cryptography.OmniAgreementPrivateKey Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniAgreementPrivateKey? left, global::Omnius.Core.Cryptography.OmniAgreementPrivateKey? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniAgreementPrivateKey? left, global::Omnius.Core.Cryptography.OmniAgreementPrivateKey? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniAgreementPrivateKey)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniAgreementPrivateKey)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniAgreementPrivateKey? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.CreationTime != target.CreationTime) return false;
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PrivateKey.Span, target.PrivateKey.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniAgreementPrivateKey>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniAgreementPrivateKey value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.CreationTime != global::Omnius.Core.RocketPack.Timestamp.Zero)
                {
                    w.Write((uint)1);
                    w.Write(value.CreationTime);
                }
                if (value.AlgorithmType != (OmniAgreementAlgorithmType)0)
                {
                    w.Write((uint)2);
                    w.Write((ulong)value.AlgorithmType);
                }
                if (!value.PrivateKey.IsEmpty)
                {
                    w.Write((uint)3);
                    w.Write(value.PrivateKey.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniAgreementPrivateKey Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::Omnius.Core.RocketPack.Timestamp p_creationTime = global::Omnius.Core.RocketPack.Timestamp.Zero;
                OmniAgreementAlgorithmType p_algorithmType = (OmniAgreementAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_privateKey = global::System.ReadOnlyMemory<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_creationTime = r.GetTimestamp();
                                break;
                            }
                        case 2:
                            {
                                p_algorithmType = (OmniAgreementAlgorithmType)r.GetUInt64();
                                break;
                            }
                        case 3:
                            {
                                p_privateKey = r.GetMemory(8192);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniAgreementPrivateKey(p_creationTime, p_algorithmType, p_privateKey);
            }
        }
    }
    public sealed partial class OmniDigitalSignature : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniDigitalSignature>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniDigitalSignature> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniDigitalSignature>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniDigitalSignature Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniDigitalSignature>.Empty;

        static OmniDigitalSignature()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniDigitalSignature>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniDigitalSignature>.Empty = new global::Omnius.Core.Cryptography.OmniDigitalSignature(string.Empty, (OmniDigitalSignatureAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxNameLength = 32;
        public static readonly int MaxPublicKeyLength = 8192;
        public static readonly int MaxPrivateKeyLength = 8192;

        public OmniDigitalSignature(string name, OmniDigitalSignatureAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> publicKey, global::System.ReadOnlyMemory<byte> privateKey)
        {
            if (name is null) throw new global::System.ArgumentNullException("name");
            if (name.Length > 32) throw new global::System.ArgumentOutOfRangeException("name");
            if (publicKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("publicKey");
            if (privateKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("privateKey");

            this.Name = name;
            this.AlgorithmType = algorithmType;
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (name != default) ___h.Add(name.GetHashCode());
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!publicKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(publicKey.Span));
                if (!privateKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(privateKey.Span));
                return ___h.ToHashCode();
            });
        }

        public string Name { get; }
        public OmniDigitalSignatureAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> PublicKey { get; }
        public global::System.ReadOnlyMemory<byte> PrivateKey { get; }

        public static global::Omnius.Core.Cryptography.OmniDigitalSignature Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniDigitalSignature? left, global::Omnius.Core.Cryptography.OmniDigitalSignature? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniDigitalSignature? left, global::Omnius.Core.Cryptography.OmniDigitalSignature? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniDigitalSignature)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniDigitalSignature)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniDigitalSignature? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Name != target.Name) return false;
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PublicKey.Span, target.PublicKey.Span)) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PrivateKey.Span, target.PrivateKey.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniDigitalSignature>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniDigitalSignature value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Name != string.Empty)
                {
                    w.Write((uint)1);
                    w.Write(value.Name);
                }
                if (value.AlgorithmType != (OmniDigitalSignatureAlgorithmType)0)
                {
                    w.Write((uint)2);
                    w.Write((ulong)value.AlgorithmType);
                }
                if (!value.PublicKey.IsEmpty)
                {
                    w.Write((uint)3);
                    w.Write(value.PublicKey.Span);
                }
                if (!value.PrivateKey.IsEmpty)
                {
                    w.Write((uint)4);
                    w.Write(value.PrivateKey.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniDigitalSignature Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                string p_name = string.Empty;
                OmniDigitalSignatureAlgorithmType p_algorithmType = (OmniDigitalSignatureAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_publicKey = global::System.ReadOnlyMemory<byte>.Empty;
                global::System.ReadOnlyMemory<byte> p_privateKey = global::System.ReadOnlyMemory<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_name = r.GetString(32);
                                break;
                            }
                        case 2:
                            {
                                p_algorithmType = (OmniDigitalSignatureAlgorithmType)r.GetUInt64();
                                break;
                            }
                        case 3:
                            {
                                p_publicKey = r.GetMemory(8192);
                                break;
                            }
                        case 4:
                            {
                                p_privateKey = r.GetMemory(8192);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniDigitalSignature(p_name, p_algorithmType, p_publicKey, p_privateKey);
            }
        }
    }
    public sealed partial class OmniCertificate : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniCertificate>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniCertificate> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniCertificate>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniCertificate Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniCertificate>.Empty;

        static OmniCertificate()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniCertificate>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniCertificate>.Empty = new global::Omnius.Core.Cryptography.OmniCertificate(string.Empty, (OmniDigitalSignatureAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxNameLength = 32;
        public static readonly int MaxPublicKeyLength = 8192;
        public static readonly int MaxValueLength = 8192;

        public OmniCertificate(string name, OmniDigitalSignatureAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> publicKey, global::System.ReadOnlyMemory<byte> value)
        {
            if (name is null) throw new global::System.ArgumentNullException("name");
            if (name.Length > 32) throw new global::System.ArgumentOutOfRangeException("name");
            if (publicKey.Length > 8192) throw new global::System.ArgumentOutOfRangeException("publicKey");
            if (value.Length > 8192) throw new global::System.ArgumentOutOfRangeException("value");

            this.Name = name;
            this.AlgorithmType = algorithmType;
            this.PublicKey = publicKey;
            this.Value = value;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (name != default) ___h.Add(name.GetHashCode());
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!publicKey.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(publicKey.Span));
                if (!value.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(value.Span));
                return ___h.ToHashCode();
            });
        }

        public string Name { get; }
        public OmniDigitalSignatureAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> PublicKey { get; }
        public global::System.ReadOnlyMemory<byte> Value { get; }

        public static global::Omnius.Core.Cryptography.OmniCertificate Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniCertificate? left, global::Omnius.Core.Cryptography.OmniCertificate? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniCertificate? left, global::Omnius.Core.Cryptography.OmniCertificate? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniCertificate)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniCertificate)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniCertificate? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Name != target.Name) return false;
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.PublicKey.Span, target.PublicKey.Span)) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Value.Span, target.Value.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniCertificate>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniCertificate value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Name != string.Empty)
                {
                    w.Write((uint)1);
                    w.Write(value.Name);
                }
                if (value.AlgorithmType != (OmniDigitalSignatureAlgorithmType)0)
                {
                    w.Write((uint)2);
                    w.Write((ulong)value.AlgorithmType);
                }
                if (!value.PublicKey.IsEmpty)
                {
                    w.Write((uint)3);
                    w.Write(value.PublicKey.Span);
                }
                if (!value.Value.IsEmpty)
                {
                    w.Write((uint)4);
                    w.Write(value.Value.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniCertificate Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                string p_name = string.Empty;
                OmniDigitalSignatureAlgorithmType p_algorithmType = (OmniDigitalSignatureAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_publicKey = global::System.ReadOnlyMemory<byte>.Empty;
                global::System.ReadOnlyMemory<byte> p_value = global::System.ReadOnlyMemory<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_name = r.GetString(32);
                                break;
                            }
                        case 2:
                            {
                                p_algorithmType = (OmniDigitalSignatureAlgorithmType)r.GetUInt64();
                                break;
                            }
                        case 3:
                            {
                                p_publicKey = r.GetMemory(8192);
                                break;
                            }
                        case 4:
                            {
                                p_value = r.GetMemory(8192);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniCertificate(p_name, p_algorithmType, p_publicKey, p_value);
            }
        }
    }
    public sealed partial class OmniSignature : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniSignature>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniSignature> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniSignature>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniSignature Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniSignature>.Empty;

        static OmniSignature()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniSignature>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniSignature>.Empty = new global::Omnius.Core.Cryptography.OmniSignature(string.Empty, OmniHash.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxNameLength = 32;

        public OmniSignature(string name, OmniHash hash)
        {
            if (name is null) throw new global::System.ArgumentNullException("name");
            if (name.Length > 32) throw new global::System.ArgumentOutOfRangeException("name");
            this.Name = name;
            this.Hash = hash;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (name != default) ___h.Add(name.GetHashCode());
                if (hash != default) ___h.Add(hash.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public string Name { get; }
        public OmniHash Hash { get; }

        public static global::Omnius.Core.Cryptography.OmniSignature Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniSignature? left, global::Omnius.Core.Cryptography.OmniSignature? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniSignature? left, global::Omnius.Core.Cryptography.OmniSignature? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniSignature)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniSignature)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniSignature? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Name != target.Name) return false;
            if (this.Hash != target.Hash) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniSignature>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniSignature value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Name != string.Empty)
                {
                    w.Write((uint)1);
                    w.Write(value.Name);
                }
                if (value.Hash != OmniHash.Empty)
                {
                    w.Write((uint)2);
                    global::Omnius.Core.Cryptography.OmniHash.Formatter.Serialize(ref w, value.Hash, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniSignature Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                string p_name = string.Empty;
                OmniHash p_hash = OmniHash.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_name = r.GetString(32);
                                break;
                            }
                        case 2:
                            {
                                p_hash = global::Omnius.Core.Cryptography.OmniHash.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniSignature(p_name, p_hash);
            }
        }
    }
    public sealed partial class OmniHashcash : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHashcash>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniHashcash> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHashcash>.Formatter;
        public static global::Omnius.Core.Cryptography.OmniHashcash Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHashcash>.Empty;

        static OmniHashcash()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHashcash>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Cryptography.OmniHashcash>.Empty = new global::Omnius.Core.Cryptography.OmniHashcash((OmniHashcashAlgorithmType)0, global::System.ReadOnlyMemory<byte>.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxKeyLength = 32;

        public OmniHashcash(OmniHashcashAlgorithmType algorithmType, global::System.ReadOnlyMemory<byte> key)
        {
            if (key.Length > 32) throw new global::System.ArgumentOutOfRangeException("key");

            this.AlgorithmType = algorithmType;
            this.Key = key;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (algorithmType != default) ___h.Add(algorithmType.GetHashCode());
                if (!key.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(key.Span));
                return ___h.ToHashCode();
            });
        }

        public OmniHashcashAlgorithmType AlgorithmType { get; }
        public global::System.ReadOnlyMemory<byte> Key { get; }

        public static global::Omnius.Core.Cryptography.OmniHashcash Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Cryptography.OmniHashcash? left, global::Omnius.Core.Cryptography.OmniHashcash? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Cryptography.OmniHashcash? left, global::Omnius.Core.Cryptography.OmniHashcash? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Cryptography.OmniHashcash)) return false;
            return this.Equals((global::Omnius.Core.Cryptography.OmniHashcash)other);
        }
        public bool Equals(global::Omnius.Core.Cryptography.OmniHashcash? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.AlgorithmType != target.AlgorithmType) return false;
            if (!global::Omnius.Core.BytesOperations.Equals(this.Key.Span, target.Key.Span)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Cryptography.OmniHashcash>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Cryptography.OmniHashcash value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.AlgorithmType != (OmniHashcashAlgorithmType)0)
                {
                    w.Write((uint)1);
                    w.Write((ulong)value.AlgorithmType);
                }
                if (!value.Key.IsEmpty)
                {
                    w.Write((uint)2);
                    w.Write(value.Key.Span);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Cryptography.OmniHashcash Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                OmniHashcashAlgorithmType p_algorithmType = (OmniHashcashAlgorithmType)0;
                global::System.ReadOnlyMemory<byte> p_key = global::System.ReadOnlyMemory<byte>.Empty;

                for (; ; )
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_algorithmType = (OmniHashcashAlgorithmType)r.GetUInt64();
                                break;
                            }
                        case 2:
                            {
                                p_key = r.GetMemory(32);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Cryptography.OmniHashcash(p_algorithmType, p_key);
            }
        }
    }
}
