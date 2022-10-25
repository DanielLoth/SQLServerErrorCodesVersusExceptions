using BenchmarkDotNet.Running;

//_ = BenchmarkRunner.Run<NoDataAccessBenchmarks>();
//_ = BenchmarkRunner.Run<InsertBenchmarks>();

// Run under debugger
//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new BenchmarkDotNet.Configs.DebugInProcessConfig());


// Run under Release mode
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
