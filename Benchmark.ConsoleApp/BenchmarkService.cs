using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Benchmark;

[ShortRunJob, Config(typeof(Config))]
public class BenchmarkService
{
    private class Config : ManualConfig
    {
        public Config() 
        {
            SummaryStyle = 
                BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle
                (BenchmarkDotNet.Columns.RatioStyle.Trend);
        }
    }

    /// <summary>
    /// BaseLine = Mark as main method
    /// </summary>
    [Benchmark(Baseline =true)] 
    public void GetAll()
    {
        AppDbContext context = new();
        context.Products.ToListAsync();
    }

    [Benchmark]
    public void GetAllSqlRaw()
    {
        AppDbContext context = new();
        context.Products.FromSqlRaw("Select * from Products").ToListAsync();
    }
}
