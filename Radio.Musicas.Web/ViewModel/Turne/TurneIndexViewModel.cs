using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Radio.Musicas.Web.ViewModel.Turne
{
    public class TurneIndexViewModel
    {
        public long IdTurne { get; set; }
        [Display(Name="Nome da Turne")]
        public string NomeTurne { get; set; }
        [Display(Name = "Nome do Artista")]
        public string MusicaTurne { get; set; }
    }
}