using Microsoft.EntityFrameworkCore;

namespace Refugiados1.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<AtenderDadiva> AtenderDadiva { get; set; }

        public DbSet<CriarDadiva> CriarDadiva { get; set; }

        public DbSet<EscolherDadiva> EscolherDadiva { get; set; }

        public DbSet<SolicitarDadiva> SolicitarDadiva { get; set; }

        public DbSet<Avaliacao> Avaliacao { get; set; }

    }
}
