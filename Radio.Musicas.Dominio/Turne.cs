using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio.Musicas.Dominio
{
    public class Turne
    {
        public long IdTurne { get; set; }
        public string NomeTurne { get; set; }
        public virtual Musica musica { get; set; }
        public int IdMusica {get;set;}
    }
}
