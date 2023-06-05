using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace AsNoTracking;

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

    //[Benchmark(Baseline = true)]
    //public void GetAllWithTracking()
    //{
    //    AppDbContext context = new();

    //    context.Products.ToListAsync();
    //}

    //[Benchmark]
    //public void GetAllWithAsNoTracking()
    //{
    //    AppDbContext context = new();

    //    context.Products.AsNoTracking().ToListAsync();
    //}

    //[Benchmark(Baseline = true)]
    //public void GetFirstWithTracking()
    //{
    //    AppDbContext context = new();

    //    context.Products.FirstAsync();
    //}

    //[Benchmark]
    //public void GetFirstAsNoTracking()
    //{
    //    AppDbContext context = new();

    //    context.Products.AsNoTracking().FirstAsync();
    //}

    public void Find()
    {
        AppDbContext context = new();

        context.Products.FromSqlRaw("Select * From").AsNoTracking().ToListAsync();
    }
}
