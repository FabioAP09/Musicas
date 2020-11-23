using AutoMapper;
using Radio.Musicas.Dominio;
using Radio.Musicas.Web.ViewModel.Musica;
using Radio.Musicas.Web.ViewModel.Turne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Radio.Musicas.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<MusicaViewModel, Musica>();
            Mapper.CreateMap<TurneViewModel, Turne>();
        }
    }
}