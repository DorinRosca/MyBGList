using Microsoft.EntityFrameworkCore;
using MyBGList.Models;

namespace MyBGList.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<BoardGame> BoardGames => Set<BoardGame>();
    public DbSet<Domain> Domains => Set<Domain>();
    public DbSet<Mechanic> Mechanics => Set<Mechanic>();
    public DbSet<BoardGames_Domains> BoardGames_Domains => Set<BoardGames_Domains>();
    public DbSet<BoardGames_Mechanics> BoardGames_Mechanics => Set<BoardGames_Mechanics>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
 
        modelBuilder.Entity<BoardGames_Domains>()
            .HasKey(i => new { i.BoardGameId, i.DomainId });
 
        modelBuilder.Entity<BoardGames_Domains>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGames_Domains)
            .HasForeignKey(f => f.BoardGameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
 
        modelBuilder.Entity<BoardGames_Domains>()
            .HasOne(o => o.Domain)
            .WithMany(m => m.BoardGames_Domains)
            .HasForeignKey(f => f.DomainId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
 
        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasKey(i => new { i.BoardGameId, i.MechanicId });
 
        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasOne(x => x.BoardGame)
            .WithMany(y => y.BoardGames_Mechanics)
            .HasForeignKey(f => f.BoardGameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
 
        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasOne(o => o.Mechanic)
            .WithMany(m => m.BoardGames_Mechanics)
            .HasForeignKey(f => f.MechanicId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Publisher>()
            .HasKey(p => new { p.Id });

        modelBuilder.Entity<BoardGame>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<BoardGame>()
            .HasOne(b => b.Publisher)
            .WithMany(m => m.BoardGames)
            .HasForeignKey(f => f.PublisherId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGames_Categories>()
            .HasKey(b => new { b.BoardGameId, b.CategoryId });
        modelBuilder.Entity<BoardGames_Categories>()
            .HasOne(o => o.BoardGame)
            .WithMany(m => m.BoardGames_Categories)
            .HasForeignKey(f => f.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}