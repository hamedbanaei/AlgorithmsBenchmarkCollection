namespace CryptographyAlgorithmsBenchmarks
{
    [BenchmarkDotNet.Attributes.MemoryDiagnoser]
    [BenchmarkDotNet.Attributes.RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Arabic)]
    [BenchmarkDotNet.Attributes.Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class HashAlgorithms
    {
        byte[] bytRawData = null;
        private int RawDataSize = 0;

        [BenchmarkDotNet.Attributes.GlobalSetup]
        public void GlobalSetup()
        {
            RawDataSize = 2;
            bytRawData = System.Security.Cryptography.RandomNumberGenerator.GetBytes(RawDataSize);
        }

        [BenchmarkDotNet.Attributes.Arguments()]
        public void MD5HashAlgorithm() => System.Security.Cryptography.MD5.HashData(bytRawData);

        [BenchmarkDotNet.Attributes.Benchmark]
        public void SHA1HashAlgorithm() => System.Security.Cryptography.SHA1.HashData(bytRawData);

        [BenchmarkDotNet.Attributes.Benchmark]
        public void SHA256HashAlgorithm() => System.Security.Cryptography.SHA256.HashData(bytRawData);

        [BenchmarkDotNet.Attributes.Benchmark]
        public void SHA384HashAlgorithm() => System.Security.Cryptography.SHA384.HashData(bytRawData);

        [BenchmarkDotNet.Attributes.Benchmark]
        public void SHA512HashAlgorithm() => System.Security.Cryptography.SHA512.HashData(bytRawData);
    }
}
