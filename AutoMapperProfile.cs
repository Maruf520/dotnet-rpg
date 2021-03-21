﻿using AutoMapper;
using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
           /* CreateMap<UpdateCharacterDto, GetCharacterDto>();*/
            
        }
    }
}
