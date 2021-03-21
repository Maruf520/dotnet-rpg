using AutoMapper;
using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterServices
{
    public class CharacterService : ICharacterSeervice
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
        new Character{Id = 1,Name = "Sam"}
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id +1);
            characters.Add(character);
            ServiceResponse.Data = (characters.Select(C => _mapper.Map<GetCharacterDto>(C))).ToList();
            return  ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetALlCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = (characters.Select(C => _mapper.Map<GetCharacterDto>(C))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
                                   _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character character = characters.FirstOrDefault(c => c.Id == updateCharacterDto.Id);
            character.Name = updateCharacterDto.Name;
            character.Class = updateCharacterDto.Class;
            character.Defence = updateCharacterDto.Defence;
            character.HitPoint = updateCharacterDto.HitPoint;
            character.Intelligence = updateCharacterDto.Intelligence;
            character.Strength = updateCharacterDto.Strength;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(updateCharacterDto);
            return serviceResponse;
        }
    }
}
