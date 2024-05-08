using DTO.MotivationLetter;
using DTO.MotivationLetterDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LetterController : ControllerBase
    {
        private readonly MotivationLetterRepository letterRepository;
        public LetterController(MotivationLetterRepository letterRepository)
        {
            this.letterRepository = letterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MotivationLetterGetDTO>>> GetAll()
        {
            try
            {
                return Ok(await letterRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotivationLetterGetDTO>> GetById(int id)
        {
            try
            {
                var letter = await letterRepository.GetByIdAsync(id);
                if (letter == null)
                {
                    return NotFound("Letter not found");
                }
                return Ok(await letterRepository.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(MotivationLetterCreateDTO letterCreateDTO)
        {
            try
            {
                var creation = await letterRepository.CreateAsync(letterCreateDTO);
                if (!creation)
                {
                    return BadRequest("Something went wrong while creating");
                }
                return Ok("Motivation Letter Created well");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, MotivationLetterCreateDTO letterCreateDTO)
        {
            try
            {
                var creation = await letterRepository.UpdateAsync(id, letterCreateDTO);
                if (!creation)
                {
                    return BadRequest("Something went wrong while updating");
                }
                return Ok("Motivation Letter Updated well");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var delete = await letterRepository.DeleteAsync(id);
                if (delete)
                {
                    return Ok(await letterRepository.DeleteAsync(id));
                }
                return BadRequest("Something went wrong while deleting");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
