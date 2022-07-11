using System;
using BenchmarkDotNet.Running;

namespace LinqToLookupToDict_ForEach_For
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<GenerateDictKeyEntityLev4ValuesKeyEntityLevel1Benchmarks>();
        }
    }
}