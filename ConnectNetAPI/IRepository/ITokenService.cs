using ConnectNet.Models;

namespace ConnectNet.IRepository
{
    public interface ITokenService
    {
        public string GetTokenAsync(AppUser appuser);
    }
}   
