using AutoMapper;
using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Dtos.Skill;
using dotnet_rpg.Dtos.Weapon;
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
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkill.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            /* CreateMap<UpdateCharacterDto, GetCharacterDto>();*/
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            
        }
    }
}
