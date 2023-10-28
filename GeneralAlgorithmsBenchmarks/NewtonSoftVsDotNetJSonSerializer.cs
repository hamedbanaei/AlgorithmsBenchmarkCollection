namespace GeneralAlgorithmsBenchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class NewtonSoftVsDotNetJSonSerializer
{
	[BenchmarkDotNet.Attributes.Params(1_000, 2_000, 5_000, 10_000,
		20_000, 50_000, 100_000, 200_000, 500_000, 1_000_000)]
	public int ListSize { get; set; }

	public System.Collections.Generic.List<ComplexPerson> PeopleList = null;

	[BenchmarkDotNet.Attributes.GlobalSetup]
	public void GlobalSetup()
	{
		if (PeopleList == null) PeopleList = new();

		GlobalAndIterationSetup.FillWithFakeTestData(PeopleList, ListSize);
	}

	[BenchmarkDotNet.Attributes.Benchmark]
	public string SystemTexJsonSerializer()
	{
		string result =
			System.Text.Json.JsonSerializer.Serialize(PeopleList);

		return (result);
	}

	[BenchmarkDotNet.Attributes.Benchmark]
	public string NewtonSoftJsonSerializer()
	{
		string result =
			Newtonsoft.Json.JsonConvert.SerializeObject(PeopleList);

		return (result);
	}
}
