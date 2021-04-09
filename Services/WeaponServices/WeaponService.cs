using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Dtos.Weapon;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.WeaponServices
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor,IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto addWeaponDto)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character =  _context.Characters
                    .FirstOrDefault(c => c.Id == addWeaponDto.CharacterId &&
                c.User.Id == int.Parse( _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if(character == null)
                {
                    response.Success = false;
                    response.Message = "Character Not Found";
                }
                Weapon weapon = new Weapon
                {
                    Name = addWeaponDto.Name,
                    Damage = addWeaponDto.Damage,
                    CharacterId = addWeaponDto.CharacterId,
                };
                await _context.AddAsync(weapon);
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
