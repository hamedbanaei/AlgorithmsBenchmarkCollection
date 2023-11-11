namespace GeneralAlgorithmsBenchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class ImprovePerformanceWithNameOf
{
	[BenchmarkDotNet.Attributes.Benchmark]
	public void ToStringMethod()
	{
		string result = System.Drawing.Color.AliceBlue.ToString();
	}

	[BenchmarkDotNet.Attributes.Benchmark]
	public void NameOfMethod()
	{
		string result = nameof(System.Drawing.Color.AliceBlue);
	}
}
