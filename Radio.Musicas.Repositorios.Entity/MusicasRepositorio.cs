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
    public class MusicasRepositorio: RepositorioGenericoEntity<Musica,int>
    {
        public MusicasRepositorio(MusicaDbContext contexto)
            : base (contexto)
        {

        }
        public override List<Musica> Selecionar()
        {
            return _contexto.Set<Musica>().Include(p => p.Turnes).ToList();

        }
        public override Musica SelecionarPorId(int id)
        {
            return _contexto.Set<Musica>().Include(p => p.Turnes).SingleOrDefault(a => a.Id == id);
        }
    }
}
