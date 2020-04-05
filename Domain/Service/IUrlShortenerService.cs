using System;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Service
{
    public interface IUrlShortenerService
    {
        string GenerateUniqueId(string longUrl);

        Task IncrementVisitCount(string uniqueId);

        ServiceResponse ValidateUrl(string longUrl);

    }
}