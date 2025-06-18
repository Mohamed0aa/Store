using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace presistence.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _context;
        public DbInitializer(StoreDbContext context)
        {
            _context = context;
        }
        public async Task InitializeAsync()
        {
            //create db if  dosent exists and apply migrations
            if (_context.Database.GetPendingMigrations().Any())
            {
                await _context.Database.MigrateAsync();
            }
            try
            {
                //seeding Data
                if (!_context.ProductTyps.Any())
                {
                    //read data
                    var Data = await File.ReadAllTextAsync("..\\Infrastructure\\presistence\\Data\\Seeding\\types.json");

                    //convert data from string to c# opject
                    var Datas = JsonSerializer.Deserialize<List<ProductType>>(Data);

                    if (Datas is not null && Datas.Any())
                    {
                        await _context.ProductTyps.AddRangeAsync(Datas);
                        await _context.SaveChangesAsync();
                    }
                }
                //brands
                if (!_context.ProductBrands.Any())
                {
                    //read data
                    var Data = await File.ReadAllTextAsync("..\\Infrastructure\\presistence\\Data\\Seeding\\brands.json");

                    //convert data from string to c# opject
                    var Datas = JsonSerializer.Deserialize<List<ProductBrand>>(Data);

                    if (Datas is not null && Datas.Any())
                    {
                        await _context.ProductBrands.AddRangeAsync(Datas);
                        await _context.SaveChangesAsync();
                    }
                }
                //product
                if (!_context.Products.Any())
                {
                    //read data
                    var Data = await File.ReadAllTextAsync("..\\Infrastructure\\presistence\\Data\\Seeding\\products.json");

                    //convert data from string to c# opject
                    var Datas = JsonSerializer.Deserialize<List<Product>>(Data);

                    if (Datas is not null && Datas.Any())
                    {
                        await _context.Products.AddRangeAsync(Datas);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                {
                    throw;
                }


            }
        }
    }
}
