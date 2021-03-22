using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;
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

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
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

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);

                serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetALlCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = (dbCharacters.Select(C => _mapper.Map<GetCharacterDto>(C))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
                                   
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updateCharacterDto.Id);
                character.Name = updateCharacterDto.Name;
                character.Class = updateCharacterDto.Class;
                character.Defence = updateCharacterDto.Defence;
                character.HitPoint = updateCharacterDto.HitPoint;
                character.Intelligence = updateCharacterDto.Intelligence;
                character.Strength = updateCharacterDto.Strength;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        
    }
}
