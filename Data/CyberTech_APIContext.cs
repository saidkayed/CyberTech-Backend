using CyberTech_Backend.Model;
using CyberTech_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CyberTech_Backend.Data;

public class CyberTech_APIContext : DbContext
{
    public CyberTech_APIContext(DbContextOptions<CyberTech_APIContext> options)
        : base(options)
    {
    }

    public DbSet<CyberTech_Backend.Models.Move> Move
    {
        get; set;
    }

    public DbSet<CyberTech_Backend.Models.CyberTech> CyberTech
    {
        get; set;
    }

    public DbSet<CyberTech_Backend.Models.Type> Type
    {
        get; set;
    }

    public DbSet<CyberTech_Backend.Models.Player> Player
    {
        get; set;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasOne(p => p.CyberTech)
            .WithOne(c => c.Player)
            .HasForeignKey<CyberTech>(c => c.PlayerId);


    }

}