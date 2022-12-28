namespace GeneralAlgorithmsBenchmarks
{
    [BenchmarkDotNet.Attributes.MemoryDiagnoser]
    [BenchmarkDotNet.Attributes.RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Arabic)]
    [BenchmarkDotNet.Attributes.Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class WritingFileBenchmark : System.Object
    {
        int intCount = 1000;

        [BenchmarkDotNet.Attributes.Benchmark(Description = $"System.IO.File.AppendAllText()")]
        public void WriteAllText()
        {
            for (int intIndex = 0; intIndex < intCount; intIndex++)
            {
                System.IO.File.AppendAllText("WriteAllText", intIndex.ToString());
            }
        }

        [BenchmarkDotNet.Attributes.Benchmark(Description = $"System.IO.StreamWriter => Write")]
        public void StreamWriter()
        {
            using (System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter("StreamWriter", false))
            {
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    oStreamWriter.Write(intIndex);
                }
                
                oStreamWriter.Flush();
                oStreamWriter.Dispose();
            }
        }

        [BenchmarkDotNet.Attributes.Benchmark(Description = $"System.IO.StreamWriter => WriteAsync")]
        public void StreamWriterWriteAsync()
        {
            using (System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter("StreamWriterAsync", false))
            {
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    oStreamWriter.WriteAsync(intIndex.ToString());
                }

                oStreamWriter.Flush();
                oStreamWriter.Dispose();
            }
        }
    }
}
