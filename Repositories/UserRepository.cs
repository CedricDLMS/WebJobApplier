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
        /// <summary>
        /// Asynchronously creates a new user in the database using the provided user data and returns a simplified DTO of the newly created user.
        /// </summary>
        /// <param name="createUserApplierDTO">The data transfer object containing the details needed to create a new user. This includes the user's age, first name, last name, city of residence, and a description.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="UserApplierSimpleDTO"/>, which includes the ID, age, first name, last name, city, and description of the newly created user.</returns>
        /// <remarks>
        /// This method performs the following operations:
        /// - Constructs a new <see cref="UserApplier"/> object from the <paramref name="createUserApplierDTO"/>.
        /// - Adds the new user to the database context.
        /// - Saves changes to the database asynchronously.
        /// - Constructs a <see cref="UserApplierSimpleDTO"/> object that represents a simplified view of the newly created user, which is then returned.
        /// This method assumes that the database context is correctly configured and the <see cref="CreateUserApplierDTO"/> is correctly populated.
        /// </remarks>
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
