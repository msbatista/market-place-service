using Domain.CatalogBrands;
using Domain.CatalogTypes;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DataAccess;

/// <summary>
/// Seed data.
/// </summary>
public static class SeedData
{
    /// <summary>
    /// Seed data into database after database context is created.
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogBrand>().HasData(GetPreconfiguredBrandData());
        modelBuilder.Entity<CatalogType>().HasData(GetPreconfiguredTypeData());
    }

    private static List<CatalogBrand> GetPreconfiguredBrandData()
    {
        return new List<CatalogBrand>() 
        {
            new CatalogBrand(new(Guid.Parse("3005f178-7201-46f9-8d8a-b10098190941")), "Samsung"),
            new CatalogBrand(new(Guid.Parse("36820a2a-d221-4f36-9978-d6316680dc08")), "HP"),
            new CatalogBrand(new(Guid.Parse("a6550e74-5abc-473d-9e4c-e344045e4906")), "EPSON"),
            new CatalogBrand(new(Guid.Parse("9335a45a-48ec-4c6e-accc-8810a5f34355")), "Acer"),
            new CatalogBrand(new(Guid.Parse("d32ca6f8-6369-4347-952c-5c51d3925fd4")), "Dell"),
            new CatalogBrand(new(Guid.Parse("72f6b938-d8c1-4810-bd89-ce09a384b51c")), "LG"),
            new CatalogBrand(new(Guid.Parse("c3860e8a-0d9f-4d27-a3b1-374abbeb892c")), "Philips"),
        };
    }

    private static List<CatalogType> GetPreconfiguredTypeData()
    {
        return new List<CatalogType>() 
        {
            new CatalogType(new(Guid.Parse("31481818-7842-4c3e-829c-62ce7e52bed7")), "Acessórios"),
            new CatalogType(new(Guid.Parse("09409bfc-6239-4387-bab0-dcfa7edbf117")), "Peças e Componentes"),
            new CatalogType(new(Guid.Parse("645b0d9c-3b0d-4296-a545-31580dd2ddb2")), "Notebooks"),
            new CatalogType(new(Guid.Parse("02e67b19-81e9-497e-bdf3-6a482a0d9130")), "Monitores"),
            new CatalogType(new(Guid.Parse("cebbd28c-16b2-4835-bc8a-4209c5905a3e")), "Impressoras e Acessórios"),
            new CatalogType(new(Guid.Parse("54b39369-4af5-46f3-91b1-93936822a78b")), "Tablets"),
            new CatalogType(new(Guid.Parse("c0f7edc8-042c-4fac-a68b-18ce8df9cc79")), "Smart phones"),
            new CatalogType(new(Guid.Parse("fdbe0bbe-1319-4b78-8882-376a483d5a42")), "Memória e Armazenamento de Dados"),
        };
    }
}
