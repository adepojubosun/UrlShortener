using System.Threading.Tasks;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Persistence;
using UrlShortener.Domain.Model;

namespace UrlShortener.Domain.Repository
{
    public class UrlShortenerRepository : IUrlShortenerRepository
    {
        private readonly AppDbContext _dbContext;                  

        public UrlShortenerRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        
        public async Task<UrlShortenerModel> GetLongUrlAsync(string uniqueId)
        {
            return await _dbContext.UrlShorteners.SingleOrDefaultAsync(us => us.UniqueId == uniqueId);
        }

        public async Task<UrlShortenerModel> CreateShortUrlAsync(UrlShortenerModel urlShortener)
        {
          await _dbContext.AddAsync(urlShortener);
          return urlShortener;
        }

        public void UpdateUrlShortener(UrlShortenerModel urlShortenerModel)
        {
            _dbContext.Update(urlShortenerModel);
        }
    }
}