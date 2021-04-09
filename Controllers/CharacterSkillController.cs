using dotnet_rpg.Dtos.CharacterSkill;
using dotnet_rpg.Services.CharacterSkillService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _charcterSkillSevice;
        public CharacterSkillController(ICharacterSkillService charcterSkillSevice)
        {
            _charcterSkillSevice = charcterSkillSevice;
        }

        [HttpPost]
        public async Task<IActionResult> AddCharcterSkill(AddCharacterSkillDto newCharacterSkillDto)
        {
            return Ok(await _charcterSkillSevice.AddCharacterSkill(newCharacterSkillDto));
        }
    }

}
