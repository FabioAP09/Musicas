using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Radio.Musicas.Web.ViewModel.Musica
{
    public class MusicaIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Titulo da Música")]
        public string Titulo { get; set; }
        [Display(Name = "Artista do Álbum")]
        public string Artista { get; set; }
        [Display(Name = "Titulo do Álbum")]
        public string Album { get; set; }
        [Display(Name = "Ano do Álbum")]
        public int Ano { get; set; }
        [Display(Name ="E-mail para contato")]
        public string Email { get; set; }
    }
}