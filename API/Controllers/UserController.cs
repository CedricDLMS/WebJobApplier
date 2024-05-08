using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly UserRepository userRepository;
        public UserController(AppDbContext appDbContext, UserRepository userRepository)
        {
            this.appDbContext = appDbContext;
            this.userRepository = userRepository;
        }


        [HttpPost]
        public async Task<IActionResult> createUser(CreateUserApplierDTO createUserApplierDTO)
        {
            return Ok(await this.userRepository.CreateUserAsync(createUserApplierDTO));
        }
    }
}
