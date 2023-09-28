using System.Linq;

namespace GeneralAlgorithmsBenchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class ForeachBenchmark
{
    [BenchmarkDotNet.Attributes.Params(1_000, 2_000, 5_000, 10_000, 20_000, 50_000,
        100_000, 200_000, 500_000, 1_000_000)]
    public int ListSize { get; set; }

    public System.Collections.Generic.List<Person> PeopleList = null;

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        PeopleList = new();

        for (int i = 0; i < PeopleList.Count; i++)
        {
            PeopleList.Add(new Person { Age = i, Name = "" });
        }
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void UsingForeachLoop()
    {
        foreach (Person person in PeopleList)
        {
            person.Name = "new Name!";
        }
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void UsingLinqForeach()
    {
        PeopleList.ForEach(person => { person.Name = "new Name?"; });
    }
}
