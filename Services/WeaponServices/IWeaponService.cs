using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Dtos.Weapon;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.WeaponServices
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto addWeaponDto);
    }
}
