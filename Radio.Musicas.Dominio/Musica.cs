using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio.Musicas.Dominio
{
   public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Artista { get; set; }

        public string Album { get; set; }
        public int Ano { get; set; }

        public string Email { get; set; }

        public virtual List<Turne> Turnes { get; set; }
    }
}
