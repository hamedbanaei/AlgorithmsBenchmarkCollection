namespace GeneralAlgorithmsBenchmarks
{
    [BenchmarkDotNet.Attributes.MemoryDiagnoser]
    [BenchmarkDotNet.Attributes.RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Arabic)]
    [BenchmarkDotNet.Attributes.Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class StringConcatenationBenchmark
    {
        string[] strList = null;

        public StringConcatenationBenchmark()
        {
            strList = new string[26];

            // Right Capital Alphabet int The Array
            for (int intIndex = 65; intIndex <= 90; intIndex++)
            {
                strList[intIndex - 65] = ((char)intIndex).ToString();
            }
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public string Concat()
        {
            string strResult = string.Empty;

            foreach (string item in strList)
            {
                strResult += item;
            }

            return (strResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public string StringFormat()
        {
            string strResult = string.Empty;

            foreach (string item in strList)
            {
                strResult += string.Format("{0}", item);
            }

            return (strResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public string DollarString()
        {
            string strResult = string.Empty;

            foreach (string item in strList)
            {
                strResult += $"{item}";
            }

            return (strResult);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public System.IO.MemoryStream StreamWriter()
        {
            string strResult = System.String.Empty;

            System.IO.MemoryStream oMemoryStream = new System.IO.MemoryStream();
            System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(oMemoryStream);

            foreach (string item in strList)
            {
                oStreamWriter.Write(item);
            }

            oStreamWriter.Flush();
            oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);

            oMemoryStream.Flush();

            return (oMemoryStream);
        }

        [BenchmarkDotNet.Attributes.Benchmark]
        public string StringWriter()
        {
            string strResult = string.Empty;

            System.IO.StringWriter oStringWriter =
                new System.IO.StringWriter();

            foreach (string item in strList)
            {
                oStringWriter.Write(item);
            }

            strResult = oStringWriter.ToString();

            return (strResult);
        }
    }
}
