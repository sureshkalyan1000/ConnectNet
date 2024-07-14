using ConnectNet.Entities;
using ConnectNet.IRepository;
using ConnectNet.Models;
using ConnectNet.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ConnectNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await exist(registerDTO.userName)) { return BadRequest("Username Already exists"); }
            using var hmac = new HMACSHA512();
            var AppUser = new AppUser
            {
                UserName = registerDTO.userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.password)),
                PasswordSalt = hmac.Key
            };
            await context.AppUsers.AddAsync(AppUser);
            await context.SaveChangesAsync();
            return Ok(new UserDTO
            {
                username = AppUser.UserName,
                token = tokenService.GetTokenAsync(AppUser)
            });
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> login(RegisterDTO registerDTO)
        {
            var user = await context.AppUsers.FirstOrDefaultAsync(x => x.UserName == registerDTO.userName);
            if (user == null) { return Unauthorized("user is not exist"); }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.password));
            for (var i = 0; i < registerDTO.password.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i]) { return BadRequest("invalid password"); }
            }
            return Ok(new UserDTO
            {
                username = user.UserName,
                token = tokenService.GetTokenAsync(user)
            });
        }
        [HttpGet]
        [Route("GetUser")]
        public async Task<List<AppUser>> GetUser()
        {
            return await context.AppUsers.ToListAsync();
        }
        private async Task<bool> exist(string username)
        {
            return await context.AppUsers.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
