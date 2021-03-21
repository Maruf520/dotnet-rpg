using dotnet_rpg.Dtos.Characters;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterServices;
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
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterSeervice _CharacterServices;
        public CharacterController(ICharacterSeervice CharacterServices)
        {
            _CharacterServices = CharacterServices;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> Get()

        {
            return Ok(await _CharacterServices.GetALlCharacter());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok( await _CharacterServices.GetCharacterById(id));
        }


        [HttpPost]
        public async Task<IActionResult> AddCharcter(AddCharacterDto character)
        {
            _CharacterServices.AddCharacter(character);
            return Ok(await _CharacterServices.AddCharacter(character));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharcter(UpdateCharacterDto updateCharacterDto)
        {
            ServiceResponse<GetCharacterDto> response = await _CharacterServices.UpdateCharacter(updateCharacterDto);
            if(response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("id ")]
        public async Task<IActionResult> Delete (int id)
        {
            ServiceResponse < List < GetCharacterDto >> response = await _CharacterServices.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
