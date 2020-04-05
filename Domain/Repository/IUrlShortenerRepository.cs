using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;


namespace UrlShortener.Domain.Repository
{
    public interface IUrlShortenerRepository
    {
         Task<UrlShortenerModel> GetLongUrlAsync(string uniqueId);
         Task<UrlShortenerModel> CreateShortUrlAsync(UrlShortenerModel urlShortener);
         void UpdateUrlShortener(UrlShortenerModel urlShortenerModel);
    }
}