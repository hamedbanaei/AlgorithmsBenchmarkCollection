//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.SkipTakeVsTakeRange>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.WhereAndSelectPriority>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.ImprovePerformanceWithAsNoTracking>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.TraditionalUpdateVsExecuteUpdate>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.TraditionalDeleteVsExecuteDelete>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.ReturnNullVsEmptyCollection>();
var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.ImprovePerformanceWithProjection>();