using ConnectNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ConnectNet.Entities
{
    public class Seed
    {
        public static async Task SeedUser(DataContext dbContext)
        {
            if (await dbContext.AppUsers.AnyAsync()) { return; }

            var userData = await File.ReadAllTextAsync("Migrations/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                await dbContext.AddAsync(user);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
