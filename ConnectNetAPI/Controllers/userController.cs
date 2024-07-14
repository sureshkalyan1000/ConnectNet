using AutoMapper;
using ConnectNet.Models;
using ConnectNet.Models.DTOs;
using ConnectNet.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConnectNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public userController(IUserRepository userRepository, IMapper mapper) 
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        // GET: api/<userController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<memberDTO>>> Get()
        {
            var user = await this.userRepository.GetMenberAsync();
            return Ok(user);
        }

       // [HttpGet("{id}")]
       // public async Task<AppUser> GetById(int id)
       // {
       //     return await this.userRepository.GetUserById(id);
       // }

        [HttpGet("{name}")]
        [Authorize]
        public async Task<memberDTO> GetByUsername(string name)
        {
            return await this.userRepository.GetMenberAsync(name);
        }

        // POST api/<userController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
