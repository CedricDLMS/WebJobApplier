using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.MotivationLetter;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DTO.MotivationLetterDTOs;

namespace Repositories
{
    /// <summary>
    /// Motivation Letter Repository containing all methods
    /// </summary>

    public class MotivationLetterRepository
    {
        private readonly AppDbContext _context;

        public MotivationLetterRepository(AppDbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Retrieves all motivation letters asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, returning a list of <see cref="MotivationLetterGetDTO"/> objects representing the motivation letters.</returns>
        public async Task<List<MotivationLetterGetDTO>> GetAllAsync()
        {
            return await _context.MotivationLetters
                                 .Select(ml => new MotivationLetterGetDTO
                                 {
                                     Id = ml.Id,
                                     Name = ml.Name, // Assuming 'Name' property is part of MotivationLetter model
                                     Content = ml.Content,
                                     SubmissionDate = ml.SubmissionDate
                                 })
                                 .ToListAsync();
        }
        /// <summary>
        /// Retrieves a motivation letter by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the motivation letter to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, returning a <see cref="MotivationLetterGetDTO"/> object representing the motivation letter, or null if not found.</returns>
        public async Task<MotivationLetterGetDTO?> GetByIdAsync(int id)
        {
            return await _context.MotivationLetters
                                 .Where(ml => ml.Id == id)
                                 .Select(ml => new MotivationLetterGetDTO
                                 {
                                     Id = ml.Id,
                                     Name = ml.Name,
                                     Content = ml.Content,
                                     SubmissionDate = ml.SubmissionDate
                                 })
                                 .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Creates a new motivation letter asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing information about the motivation letter to create.</param>
        /// <returns>A task representing the asynchronous operation, returning an <see cref="EntityEntry"/> representing the created motivation letter.</returns>
        public async Task<bool> CreateAsync(MotivationLetterCreateDTO dto)
        {
            var motivationLetter = new MotivationLetter
            {
                Name = dto.Name, // Assuming there is a 'Name' property in MotivationLetterCreateDTO
                Content = dto.Content,
                SubmissionDate = dto.SubmissionDate
            };
            var add = _context.MotivationLetters.Add(motivationLetter);
            int resultInt = await _context.SaveChangesAsync();
            bool result = resultInt > 0;
            return result;
        }
        /// <summary>
        /// Updates a motivation letter asynchronously.
        /// </summary>
        /// <param name="id">The ID of the motivation letter to update.</param>
        /// <param name="dto">The DTO containing updated information about the motivation letter.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the update is successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(int id, MotivationLetterCreateDTO dto)
        {
            var motivationLetter = await _context.MotivationLetters.FindAsync(id);
            if (motivationLetter != null)
            {
                motivationLetter.Name = dto.Name; // Update the 'Name' property
                motivationLetter.Content = dto.Content;
                motivationLetter.SubmissionDate = dto.SubmissionDate;
                _context.MotivationLetters.Update(motivationLetter);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Deletes a motivation letter by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the motivation letter to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var motivationLetter = await _context.MotivationLetters.FindAsync(id);
            if (motivationLetter != null)
            {
                _context.MotivationLetters.Remove(motivationLetter);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
