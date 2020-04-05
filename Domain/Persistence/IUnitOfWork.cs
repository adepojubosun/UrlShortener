using System.Threading.Tasks;

namespace UrlShortener.Domain.Persistence
{
    public interface IUnitOfWork
    {
         Task Complete();
    }
}