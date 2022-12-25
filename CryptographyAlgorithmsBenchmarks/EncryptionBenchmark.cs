namespace CryptographyAlgorithmsBenchmarks
{
    [BenchmarkDotNet.Attributes.MemoryDiagnoser]
    public class EncryptionBenchmark
    {
        [BenchmarkDotNet.Attributes.Benchmark]
        public byte[] AesEnctyptionAlgorithm()
        {
            byte[] bytResult = SymmetricAlgorithm.Encrypt(SymmetricAlgorithm.AesAlgorithm.CreateEncryptor(), SymmetricAlgorithm.PlainText);
            return (bytResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public byte[] AesCngEnctyptionAlgorithm()
        {
            byte[] bytResult = SymmetricAlgorithm.Encrypt(SymmetricAlgorithm.AesCngAlgorithm.CreateEncryptor(), SymmetricAlgorithm.PlainText);
            return (bytResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public byte[] DesEnctyptionAlgorithm()
        {
            byte[] bytResult = SymmetricAlgorithm.Encrypt(SymmetricAlgorithm.DesAlgorithm.CreateEncryptor(), SymmetricAlgorithm.PlainText);
            return (bytResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public byte[] TripleDesEnctyptionAlgorithm()
        {
            byte[] bytResult = SymmetricAlgorithm.Encrypt(SymmetricAlgorithm.TripleDesAlgorithm.CreateEncryptor(), SymmetricAlgorithm.PlainText);
            return (bytResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public byte[] TripleDesCngEnctyptionAlgorithm()
        {
            byte[] bytResult = SymmetricAlgorithm.Encrypt(SymmetricAlgorithm.TripleDesCngAlgorithm.CreateEncryptor(), SymmetricAlgorithm.PlainText);
            return (bytResult);
        }
    }
}