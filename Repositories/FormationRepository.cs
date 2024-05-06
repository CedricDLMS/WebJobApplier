using DTO.FormationDTOs;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FormationRepository
    {
        private readonly AppDbContext _context;

        public FormationRepository(AppDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all formations asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, returning a list of <see cref="GetFormationDTO"/> objects representing the formations.</returns>

        public async Task<List<GetFormationDTO>> GetAllAsync()
        {
            return await _context.Formations
                                 .Select(f => new GetFormationDTO
                                 {
                                     Id = f.Id,
                                     SchoolName = f.SchoolName,
                                     Description = f.Description,
                                     Diploma = f.Diploma,
                                     BeginDate = f.BeginDate,
                                     EndDate = f.EndDate
                                 })
                                 .ToListAsync();
        }

        /// <summary>
        /// Retrieves a formation by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the formation to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, returning a <see cref="GetFormationDTO"/> object representing the formation, or null if not found.</returns>

        public async Task<GetFormationDTO?> GetByIdAsync(int id)
        {
            return await _context.Formations
                                 .Where(f => f.Id == id)
                                 .Select(f => new GetFormationDTO
                                 {
                                     Id = f.Id,
                                     SchoolName = f.SchoolName,
                                     Description = f.Description,
                                     Diploma = f.Diploma,
                                     BeginDate = f.BeginDate,
                                     EndDate = f.EndDate
                                 })
                                 .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new formation asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing information about the formation to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>

        public async Task CreateAsync(CreateFormationDTO dto)
        {
            var formation = new Formation
            {
                SchoolName = dto.SchoolName,
                Description = dto.Description,
                Diploma = dto.Diploma,
                BeginDate = dto.BeginDate,
                EndDate = dto.EndDate
            };
            _context.Formations.Add(formation);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing formation asynchronously.
        /// </summary>
        /// <param name="id">The ID of the formation to update.</param>
        /// <param name="dto">The DTO containing updated information about the formation.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the update is successful, otherwise false.</returns>

        public async Task<bool> UpdateAsync(UpdateFormationDTO dto)
        {
            var formation = await _context.Formations.FindAsync(dto.Id);
            if (formation != null)
            {
                formation.SchoolName = dto.SchoolName;
                formation.Description = dto.Description;
                formation.Diploma = dto.Diploma;
                formation.BeginDate = dto.BeginDate;
                formation.EndDate = dto.EndDate;
                _context.Formations.Update(formation);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        /// <summary>
        /// Deletes a formation by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the formation to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the deletion is successful, otherwise false.</returns>

        public async Task<bool> DeleteAsync(int id)
        {
            var formation = await _context.Formations.FindAsync(id);
            if (formation != null)
            {
                _context.Formations.Remove(formation);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
