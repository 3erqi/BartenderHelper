using System.IO.Compression;
using BartenderHelper.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace BartenderHelper.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Cocktail> Cocktails => Set<Cocktail>();
    public DbSet<CocktailIngredient> CocktailIngredients => Set<CocktailIngredient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Cocktail>()
            .HasOne(c => c.Owner)
            .WithMany(u => u.Cocktails)
            .HasForeignKey(c => c.OwnerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CocktailIngredient>()
            .HasOne(i => i.Cocktail)
            .WithMany(c => c.Ingredients)
            .HasForeignKey(i => i.CocktailId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
