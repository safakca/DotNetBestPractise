using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using DataAccess.Models;

namespace DataAccess.Context;

// Sealed baska biir class a inherit edilemez
public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = LAPTOP-NQ3JPK4M\\SQLEXPRESS; " +
                                    "Initial Catalog = DotnetBestPractise; " +
                                    "Integrated Security = True;" +
                                    "Connect Timeout = 30; " +
                                    "Encrypt = False; " +
                                    "TrustServerCertificate = False; " +
                                    "ApplicationIntent = ReadWrite; " +
                                    "MultiSubnetFailover = False");
    }

    public DbSet<Product> Products { get; set; }
}
 