//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.SkipTakeVsTakeRange>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.ImprovePerformanceWithAsNoTracking>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.TraditionalUpdateVsExecuteUpdate>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.TraditionalDeleteVsExecuteDelete>();
//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.ImprovePerformanceWithProjection>();
var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks.Linq.PreferAnyOverCountForExistenceCheck>();