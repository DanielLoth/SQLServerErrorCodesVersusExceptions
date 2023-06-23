using BenchmarkDotNet.Running;
using Benchmarks;

//_ = BenchmarkRunner.Run<NoDataAccessBenchmarks>();
//_ = BenchmarkRunner.Run<InsertBenchmarks>();

// Run under debugger
//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new BenchmarkDotNet.Configs.DebugInProcessConfig());
//_ = BenchmarkRunner.Run<Benchmark>(new DebugInProcessConfig());

// Run under Release mode
//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
_ = BenchmarkRunner.Run<Benchmark>();
