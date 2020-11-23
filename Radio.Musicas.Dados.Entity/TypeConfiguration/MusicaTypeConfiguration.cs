using Radio.Musicas.Dominio;
using Radio.Musicas.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio.Musicas.Dados.Entity.TypeConfiguration
{
    class MusicaTypeConfiguration : RadioEntityAbstractConfig<Musica>
    {
        protected override void ConfiguararChaveEstrangeira()
        {
            
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Titulo");

            Property(p => p.Artista)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Artista");

            Property(p => p.Album)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Album");

            Property(p => p.Ano)
                .IsRequired()
                .HasColumnName("Ano");

            Property(p => p.Email)
                .IsRequired()
                .HasColumnName("Email");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Musica");
        }
    }
}
