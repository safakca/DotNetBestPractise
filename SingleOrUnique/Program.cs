using DataAccess.Context;
using DataAccess.Models; 

namespace SingleOrUnique;
internal class Program
{
    static void Main(string[] args)
    {
        AppDbContext context = new();

        //Product? product = context.Products.Where(x => x.Name == "Product 0").SingleOrDefault(); 

        //Console.WriteLine(product?.Name);
    }
}