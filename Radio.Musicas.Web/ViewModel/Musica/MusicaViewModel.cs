using Radio.Musicas.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Radio.Musicas.Web.ViewModel.Musica
{
    public class MusicaViewModel
    {
        [Required(ErrorMessage ="O Id é obrigatório!")]
        public int Id { get; set; }
        [Required(ErrorMessage ="O título é obrigatório!")]
        [MaxLength(100,ErrorMessage ="O título deve ter no máximo 100 caracteres!")]
        [Display(Name = "Titulo da Música")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O nome do artista é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome do artista deve ter no máximo 100 caracteres!")]
        [Display(Name = "Artista do Álbum")]
        public string Artista { get; set; }
        [Required(ErrorMessage ="O nome do álbum é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome do album deve ter no máximo 100 caracteres!")]
        [Display(Name = "Titulo do Álbum")]
       
        public string Album { get; set; }
        [Required(ErrorMessage = "O ano do álbum é obrigatório!")]
        [Display(Name = "Ano do Álbum")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        [Display(Name = "E-mail para contato")]
        [DataType(DataType.EmailAddress)]
        [Email(ErrorMessage ="O domínio do email deve ser @gmail.com")]
        public string Email { get; set; }
    }
}