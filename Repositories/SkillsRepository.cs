using DTO.SkillDTO;
using DTO.UserApplierDTOs;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Repo containing lots of methods about Skills
    /// </summary>
    public class SkillsRepository
    {
        private readonly AppDbContext _context;

        public SkillsRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new skill to the database and returns the added skill as a DTO.
        /// </summary>
        /// <param name="skill">Skill creation DTO containing the necessary information.</param>
        /// <returns>The created skill as a DTO.</returns>
        public async Task<GetSkillDTO> AddSkillAsync(SkillCreationDTO skill)
        {
            // Create new Skill to add to Db
            var newSkill = new Skills
            {
                Name = skill.Name,
                YearOfPractice = skill.YearOfPractice,
            };

            await _context.Skills.AddAsync(newSkill);
            await _context.SaveChangesAsync();

            // Map the new skill to a GetSkillDTO
            var result = new GetSkillDTO
            {
                Id = newSkill.Id,
                Name = newSkill.Name,
                YearOfPractice = newSkill.YearOfPractice
            };

            return result;
        }

        /// <summary>
        /// Retrieves all skills asynchronously.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, returning a list of skill DTOs (<see cref="GetSkillDTO"/>).
        /// </returns>
        /// <remarks>
        /// This method asynchronously retrieves all skills from the database without materializing entities.
        /// It projects directly into DTOs (<see cref="GetSkillDTO"/>) using LINQ's Select method.
        /// Each skill DTO contains the skill's ID, name, and year of practice.
        /// </remarks>
        public async Task<List<GetSkillDTO>> GetAllSkillAsync()
        {
            // Project directly into DTOs without materializing entities
            var skillDTOs = await _context.Skills
                .Select(s => new GetSkillDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    YearOfPractice = s.YearOfPractice
                })
                .ToListAsync();

            return skillDTOs;
        }

        /// <summary>
        /// Retrieves a skill by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the skill to retrieve.</param>
        /// <returns>
        /// A <see cref="GetSkillByIdDTO"/> representing the skill, or null if the skill with the specified id was not found.
        /// </returns>
        public async Task<GetSkillByIdDTO?> GetSkillByIdAsync(int id)
        {
            // Retrieve the skill from the database
            var skillDTO = await _context.Skills
                .Where(s => s.Id == id)
                .Select(s => new GetSkillByIdDTO
                {
                    // Map properties from the skill entity to the DTO
                    Id = s.Id,
                    Name = s.Name,
                    YearOfPractice = s.YearOfPractice,
                    // Map users associated with the skill to the DTO
                    User = s.UserAppliers.Select(user => user != null ? new UserWithIdAndNameDTO
                    {
                        Id = user.Id,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname
                    } : null).ToList()
                })
                .FirstOrDefaultAsync();

            // Return the skill DTO
            return skillDTO;
        }

        /// <summary>
        /// Updates a skill asynchronously based on the provided DTO and returns the updated skill.
        /// </summary>
        /// <param name="updatedSkillDTO">The DTO containing the updated skill data.</param>
        /// <returns>The updated skill as a <see cref="GetSkillDTO"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the skill with the specified ID is not found.</exception>
        public async Task<GetSkillDTO> UpdateSkillAsync(GetSkillDTO updatedSkillDTO)
        {
            // Retrieve the skill from the database based on the provided Id
            var skill = await _context.Skills.FindAsync(updatedSkillDTO.Id);

            if (skill == null)
            {
                // Skill with the specified Id was not found
                throw new Exception("Skill not found");   // TODO : Buisness Services
            }

            // Update the retrieved skill entity with the data from the provided DTO
            skill.Name = updatedSkillDTO.Name;
            skill.YearOfPractice = updatedSkillDTO.YearOfPractice;

            // Save the changes to the database
            await this._context.SaveChangesAsync();

            // Return the updated skill as a DTO
            return new GetSkillDTO
            {
                Id = skill.Id,
                Name = skill.Name,
                YearOfPractice = skill.YearOfPractice
            };
        }

        /// <summary>
        /// Deletes a skill by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the skill to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown if the skill with the specified ID is not found.</exception>
        public async Task DeleteById(int id)
        {
            // Retrieve the skill from the database based on the provided ID
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                // Skill with the specified ID was not found
                throw new ArgumentException("Skill not found", nameof(id)); // TODO : Buisness SERVICES
            }

            // Remove the skill from the database context
            _context.Skills.Remove(skill);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

    }
}
