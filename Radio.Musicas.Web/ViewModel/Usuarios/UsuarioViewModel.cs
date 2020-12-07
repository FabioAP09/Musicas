using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Radio.Musicas.Web.ViewModel.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="O Email é obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}