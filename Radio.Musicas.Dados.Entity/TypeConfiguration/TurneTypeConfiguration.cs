using Radio.Musicas.Dominio;
using Radio.Musicas.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio.Musicas.Dados.Entity.TypeConfiguration
{
    class TurneTypeConfiguration : RadioEntityAbstractConfig<Turne>
    {
        protected override void ConfiguararChaveEstrangeira()
        {
            HasRequired(p => p.Musica)
                .WithMany(p => p.Turnes)
                .HasForeignKey(fk => fk.IdMusica);
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdTurne)
                .HasColumnName("IdTurne")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(p => p.NomeTurne)
                .HasColumnName("Nome Turne")
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.IdMusica)
                .HasColumnName("IdMusica")
                .IsRequired();

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.IdTurne);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Turne");
        }
    }
}
