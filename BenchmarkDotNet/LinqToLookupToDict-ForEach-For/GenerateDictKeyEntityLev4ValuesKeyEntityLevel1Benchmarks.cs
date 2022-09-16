using AutoFixture;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LinqToLookupToDict_ForEach_For.Entities;

namespace LinqToLookupToDict_ForEach_For;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class GenerateDictKeyEntityLev4ValuesKeyEntityLevel1Benchmarks
{
    private readonly IEnumerable<EntityLevel1> _entitiesLevel1 = GenerateEntitiesLevel1();
    private static readonly GenerateDictKeyEntityLev4ValuesKeyEntityLevel1 GenerateDictKeyEntityLev4ValuesKeyEntityLevel1 = new GenerateDictKeyEntityLev4ValuesKeyEntityLevel1();

    [Benchmark]
    public void GenerateWithLinqToLookupToDictionary()
    {
        GenerateDictKeyEntityLev4ValuesKeyEntityLevel1.GenerateWithLinqToLookupToDictionary(_entitiesLevel1);
    }
        
    [Benchmark]
    public void GenerateWithForEachOnly()
    {
        GenerateDictKeyEntityLev4ValuesKeyEntityLevel1.GenerateWithForEachOnly(_entitiesLevel1);
    }
        
    [Benchmark]
    public void GenerateWithLinqAndForEach()
    {
        GenerateDictKeyEntityLev4ValuesKeyEntityLevel1.GenerateWithLinqAndForEach(_entitiesLevel1);
    }
        
    [Benchmark]
    public void GenerateWithForOnly()
    {
        GenerateDictKeyEntityLev4ValuesKeyEntityLevel1.GenerateWithForOnly(_entitiesLevel1);
    }
        
    private static IEnumerable<EntityLevel1> GenerateEntitiesLevel1()
    {
        var fixture = new Fixture
        {
            RepeatCount = 3
        };

        var entitiesLevel1 = fixture.Create<IEnumerable<EntityLevel1>>();
            
        return entitiesLevel1;
    }
}