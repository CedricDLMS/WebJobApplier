using DTO;
using DTO.UserApplierDTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// List of methods to create an user and sets parametters for it, update ect ....
    /// </summary>
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public async Task<UserApplierSimpleDTO> CreateUserAsync(CreateUserApplierDTO createUserApplierDTO)
        {
            UserApplier newUser = new UserApplier
            {
                Age = createUserApplierDTO.Age,
                Lastname = createUserApplierDTO.Lastname,
                Firstname = createUserApplierDTO.Firstname,
                HomeLocation = createUserApplierDTO.City,
                Description = createUserApplierDTO.Description,
            };
            await this._context.UserAppliers.AddAsync(newUser);
            await this._context.SaveChangesAsync();
            UserApplierSimpleDTO newUserDTO = new UserApplierSimpleDTO
            {
                Id = newUser.Id,
                Age = createUserApplierDTO.Age,
                Lastname = createUserApplierDTO.Lastname,
                Firstname = createUserApplierDTO.Firstname,
                City = createUserApplierDTO.City,
                Description = createUserApplierDTO.Description,
            };


            return newUserDTO;
        } 
    

    }
}
