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
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Musica, MusicaIndexViewModel>()
                .ForMember(p => p.Titulo, opt =>
                 {
                     opt.MapFrom(src =>
                       string.Format("{0} {1}", src.Titulo, src.Ano.ToString())
                       );
                 });
            Mapper.CreateMap<Musica, MusicaViewModel>();

            Mapper.CreateMap<Turne, TurneIndexViewModel>()
                .ForMember(p => p.MusicaTurne, opt =>
                   {
                       opt.MapFrom(src =>
                           src.Musica.Titulo);
                   });
            Mapper.CreateMap<Turne, TurneViewModel>();
        }
    }
}