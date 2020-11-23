using Radio.Musicas.Dados.Entity.TypeConfiguration;
using Radio.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Radio.Musicas.Dados.Entity.Context
{
    public class MusicaDbContext : DbContext
    {
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Turne> Turnes { get; set; }
        public MusicaDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
            modelBuilder.Configurations.Add(new TurneTypeConfiguration());
        }
    }
    

   
}
