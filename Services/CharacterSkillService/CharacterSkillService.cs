using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Dtos.CharacterSkill;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CharacterSkillService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill (AddCharacterSkillDto newCharacterSkillDto)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.CharacterSkill).ThenInclude(c => c.Skill)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkillDto.CharacterId && c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
           
               if(character == null)
                {
                    response.Success = false;
                    response.Message = "Character Not Found";
                }

                Skill skill = await _context.Skills
                     .FirstOrDefaultAsync(c => c.Id == newCharacterSkillDto.CharacterId);
                if(skill == null)
                {
                    response.Success = false;
                    response.Message = "Skil Not Found";
                    return response;
                }
                CharacterSkill characterSkill = new CharacterSkill
                {
                    Character = character,
                    Skill = skill,

                };
                await _context.CharacterSkills.AddAsync(characterSkill);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
