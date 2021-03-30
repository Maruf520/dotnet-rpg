using dotnet_rpg.Dtos.Weapon;
using dotnet_rpg.Services.WeaponServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWeapon(AddWeaponDto addWeaponDto)
        {
            return Ok(await _weaponService.AddWeapon(addWeaponDto));
        }
    }
}
