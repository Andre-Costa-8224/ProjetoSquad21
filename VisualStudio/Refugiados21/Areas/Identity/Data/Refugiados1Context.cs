using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Refugiados1.Models;

namespace Refugiados1.Data;

public class Refugiados1Context : IdentityDbContext<IdentityUser>
{
    public Refugiados1Context(DbContextOptions<Refugiados1Context> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<AtenderDadiva> AtenderDadiva { get; set; }

    public DbSet<CriarDadiva> CriarDadiva { get; set; }

    public DbSet<EscolherDadiva> EscolherDadiva { get; set; }

    public DbSet<SolicitarDadiva> SolicitarDadiva { get; set; }

    public DbSet<Avaliacao> Avaliacao { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
