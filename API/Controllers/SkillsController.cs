using DTO.SkillDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly SkillsRepository _repository;

        public SkillsController(SkillsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a new skill asynchronously.
        /// </summary>
        /// <param name="skill">The skill creation DTO.</param>
        /// <returns>
        /// A task representing the asynchronous operation, returning an action result with the added skill DTO (<see cref="GetSkillDTO"/>).
        /// </returns>
        /// <remarks>
        /// This method asynchronously adds a new skill using the provided skill creation DTO.
        /// It delegates the actual addition to the repository and returns the result as an action result.
        /// If successful, it returns an HTTP 200 OK result with the added skill DTO.
        /// If an exception occurs, it returns an HTTP 500 Internal Server Error with the exception message.
        /// </remarks>
        [HttpPost]
        [Route("AddSkill")]
        public async Task<ActionResult<GetSkillDTO>> AddSkillAsync(SkillCreationDTO skill)
        {
            try
            {
                var result = await _repository.AddSkillAsync(skill);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all skills asynchronously.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, returning an action result with a list of skill DTOs (<see cref="GetSkillDTO"/>).
        /// </returns>
        /// <remarks>
        /// This method asynchronously retrieves all skills from the repository.
        /// It returns the result as an action result with a list of skill DTOs.
        /// If successful, it returns an HTTP 200 OK result with the list of skill DTOs.
        /// If an exception occurs, it returns an HTTP 500 Internal Server Error with the exception message.
        /// </remarks>
        [HttpGet]
        [Route("GetAllSkills")]
        public async Task<ActionResult<List<GetSkillDTO>>> GetAllSkillsAsync()
        {
            try
            {
                var result = await _repository.GetAllSkillAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a skill by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the skill to retrieve.</param>
        /// <returns>
        /// A task representing the asynchronous operation, returning an action result with the skill DTO (<see cref="GetSkillByIdDTO"/>).
        /// </returns>
        /// <remarks>
        /// This method asynchronously retrieves a skill from the repository by its ID.
        /// If the skill is found, it returns an HTTP 200 OK result with the skill DTO.
        /// If the skill is not found, it returns an HTTP 404 Not Found result.
        /// If an exception occurs, it returns an HTTP 500 Internal Server Error with the exception message.
        /// </remarks>
        [HttpGet]
        [Route("GetSkillById/{id}")]
        public async Task<ActionResult<GetSkillByIdDTO>> GetSkillByIdAsync(int id)
        {
            try
            {
                var result = await _repository.GetSkillByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a skill asynchronously.
        /// </summary>
        /// <param name="updatedSkillDTO">The updated skill DTO.</param>
        /// <returns>
        /// A task representing the asynchronous operation, returning an action result with the updated skill DTO (<see cref="GetSkillDTO"/>).
        /// </returns>
        /// <remarks>
        /// This method asynchronously updates a skill using the provided updated skill DTO.
        /// It delegates the actual update to the repository and returns the result as an action result.
        /// If successful, it returns an HTTP 200 OK result with the updated skill DTO.
        /// If the skill is not found, it returns an HTTP 404 Not Found result.
        /// If an exception occurs, it returns an HTTP 500 Internal Server Error with the exception message.
        /// </remarks>
        [HttpPut]
        [Route("UpdateSkill")]
        public async Task<ActionResult<GetSkillDTO>> UpdateSkillAsync(GetSkillDTO updatedSkillDTO)
        {
            try
            {
                var result = await _repository.UpdateSkillAsync(updatedSkillDTO);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a skill by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the skill to delete.</param>
        /// <returns>
        /// A task representing the asynchronous operation, returning an action result indicating success or failure.
        /// </returns>
        /// <remarks>
        /// This method asynchronously deletes a skill from the repository by its ID.
        /// If successful, it returns an HTTP 200 OK result with a message indicating success.
        /// If the skill is not found, it returns an HTTP 404 Not Found result.
        /// If an exception occurs, it returns an HTTP 500 Internal Server Error with the exception message.
        /// </remarks>
        [HttpDelete]
        [Route("DeleteSkill/{id}")]
        public async Task<IActionResult> DeleteSkillAsync(int id)
        {
            try
            {
                await _repository.DeleteById(id);
                return Ok("Removed Well");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
