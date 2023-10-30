namespace Benchmarks.Linq;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class PreferAnyOverCountForExistenceCheck
{
	public Model.DatabaseContext DbContext { get; set; }

	[BenchmarkDotNet.Attributes.GlobalSetup]
	public void GlobalSetup()
	{
		Benchmarks.GlobalAndIterationSetup.FillDatabaseWithFakeTestData
			(testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);

		DbContext = new Model.DatabaseContext();
	}

	[BenchmarkDotNet.Attributes.Benchmark]
	public bool ExistenceCheckUsingCount()
	{
		bool blnResult = DbContext.Children
			.Count(child => child.Name == "John") > 0;

		return (blnResult);
	}

	[BenchmarkDotNet.Attributes.Benchmark]
	public bool ExistenceCheckUsingAny()
	{
		bool blnResult = DbContext.Children
			.Any(child => child.Name == "John");

		return (blnResult);
	}
}
