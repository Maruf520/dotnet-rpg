using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterServices
{
    public interface ICharacterSeervice
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetALlCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        
    }
}
