using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Practice.Models;
using Practice.Services.DataTransferObjects;

namespace Practice.Services.Automapper
{
    public static class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Dino, DTODino>()
                //.ForMember(dest => dest.DinoID, opts => opts.MapFrom(src => src.DinoID))
                //.ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Health, opts => opts.MapFrom(src => src.Health))
                //.ForMember(dest => dest.Stamina, opts => opts.MapFrom(src => src.Stamina))
                //.ForMember(dest => dest.Oxigen, opts => opts.MapFrom(src => src.Oxigen))
                //.ForMember(dest => dest.Weight, opts => opts.MapFrom(src => src.Weight))
                //.ForMember(dest => dest.Damage, opts => opts.MapFrom(src => src.Damage))
                ;
            //didnt need any custom mappings due to property names and types matching
            
            Mapper.CreateMap<Image, DTOImage>();
        }
    }
}