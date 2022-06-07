using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class InventoryContext : DbContext
{
    public DbSet<Categorie> Categorie { get; set; }

    public DbSet<Input> Input { get; set; }

    public DbSet<Inventory> Inventory { get; set; }

    public DbSet<Output> Output { get; set; }

    public DbSet<Product> Product { get; set; }

    public DbSet<Supplier> Supplier { get; set; }


    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }


}