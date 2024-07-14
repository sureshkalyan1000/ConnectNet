using ConnectNet.Models;
using ConnectNet.Models.DTOs;

namespace ConnectNet.Repository
{
    public interface IUserRepository
    {
        void update(AppUser appUser);
        Task<bool> saveallasync();
        Task<IEnumerable<AppUser>> GetUsers();
        Task<AppUser> GetUserById(int id);
        Task<AppUser> GetUserByName(string name);
        Task<memberDTO> GetMenberAsync(string name);
        Task<IEnumerable<memberDTO>> GetMenberAsync();
    }
}
