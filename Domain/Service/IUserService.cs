using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.Domain.Service
{
    public interface IUserService
    {
         Task<UserModel> Create(UserModel user, string password);
         Task Update(UserModel user, string password = null);
         Task<UserModel> AuthenticateUser(string userName, string password);

         UserModel GetById(int Id); 
    }
}