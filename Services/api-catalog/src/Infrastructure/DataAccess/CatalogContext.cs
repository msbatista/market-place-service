using System.Reflection;
using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;


/// <summary>
/// Catalog context.
/// </summary>
public sealed class CatalogContext : DbContext
{

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    /// <summary>
    /// Initialize an instance of CatalogContext.
    /// </summary>
    /// <param name="options">Db context options.</param>
    /// <returns></returns>
    public CatalogContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    {
    }

    /// <summary>
    /// Gets or sets CatalogItems.
    /// </summary>
    /// <value>DbSet<CatalogItem>.</value>
    public DbSet<CatalogItem> CatalogItems { get; set; }

    /// <summary>
    /// Gets or sets CatalogBrands.
    /// </summary>
    /// <value></value>
    public DbSet<CatalogBrand> CatalogBrands { get; set; }

    /// <summary>
    /// Get or sets CatalogTypes.
    /// </summary>
    /// <value>DbSet<CatalogType>.</value>
    public DbSet<CatalogType> CatalogTypes { get; set; }

    /// <summary>
    /// This method is called by the framework when database context is first created to build the model and its mappings in memory.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedData.Seed(modelBuilder);
    }
}
