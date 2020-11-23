using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Radio.Musicas.Web.ViewModel.Turne
{
    public class TurneViewModel
    {
        [Required(ErrorMessage ="Id obrigatorio")]
        public long IdTurne { get; set; }
        [Required(ErrorMessage = "Nome da Turne obrigatorio")]
        [Display(Name = "Nome da Turne")]
        public string NomeTurne { get; set; }
        [Required(ErrorMessage = "")]
        [Display(Name = "Selecione a música")]
        public string IdMusica { get; set; }
    }
}