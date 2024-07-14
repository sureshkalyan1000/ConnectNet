using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConnectNet.Entities;
using ConnectNet.Models;
using ConnectNet.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ConnectNet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public UserRepository(DataContext dataContext, IMapper mapper) 
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<memberDTO> GetMenberAsync(string name)
        {
            return await this.dataContext.AppUsers.Where(x => x.UserName == name)
                .ProjectTo<memberDTO>(this.mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await this.dataContext.AppUsers.FindAsync(id);
        }

        public async Task<AppUser> GetUserByName(string name)
        {
            return await this.dataContext.AppUsers
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await this.dataContext.AppUsers
                .Include(p => p.Photos)
                .ToListAsync();
        }
        public async Task<IEnumerable<memberDTO>> GetMenberAsync()
        {
            return await this.dataContext.AppUsers
                .ProjectTo<memberDTO>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> saveallasync()
        {
            return await this.dataContext.SaveChangesAsync() > 0;
        }

        public async void update(AppUser appUser)
        {
            dataContext.Entry(appUser).State = EntityState.Modified;
        }
    }
}
