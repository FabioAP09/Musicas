using Radio.Musicas.Comum.Entity;
using Radio.Musicas.Dados.Entity.Context;
using Radio.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Radio.Musicas.Repositorios.Entity
{
    public class TurnesRepositorio : RepositorioGenericoEntity<Turne,long>
    {
        public TurnesRepositorio(MusicaDbContext contexto)
            : base (contexto)
        {

        }
        public override List<Turne> Selecionar()
        {
            return _contexto.Set<Turne>().Include(p => p.Musica).ToList();

        }
        public override Turne SelecionarPorId(long id)
        {
            return _contexto.Set<Turne>().Include(p => p.Musica).SingleOrDefault(f => f.IdTurne == id);
        }
    }
}
