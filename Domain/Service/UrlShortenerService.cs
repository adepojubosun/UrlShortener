using System;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;
using UrlShortener.Domain.Repository;
using UrlShortener.Domain.Persistence;
using System.Text.RegularExpressions;

namespace UrlShortener.Domain.Service
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly IUrlShortenerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UrlShortenerService(IUrlShortenerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public string GenerateUniqueId(string longUrl)
        {
            string uniqueId = "";
            string hostname = "";
            if (longUrl.ToLower().StartsWith("http"))
            {
                Uri uri = new Uri(longUrl);
                hostname = uri.DnsSafeHost;
            }
            else
            {
                hostname = longUrl.ToLower().Split('.')[0];
            }

            uniqueId = string.Format($"{hostname.ToCharArray()[0]}{hostname.ToCharArray()[hostname.Length / 2]}{hostname.ToCharArray()[hostname.Length - 1]}{RandomGenerator()}");

            return uniqueId;
        }

        public static string RandomGenerator()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public async Task IncrementVisitCount(string uniqueId)
        {

            UrlShortenerModel tempModel = await _repository.GetLongUrlAsync(uniqueId);
            if (tempModel != null)
            {
                tempModel.VisitCount += 1;
                _repository.UpdateUrlShortener(tempModel);
                await _unitOfWork.Complete();
            }

        }

        public ServiceResponse ValidateUrl(string longUrl)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
           

            if (string.IsNullOrEmpty(longUrl))
            {
                return new ServiceResponse(false, "Please enter a link to continue!");
            }
            if (!reg.IsMatch(longUrl))
            {
                return new ServiceResponse(false, "Invalid Url, Please enter a valid link!");
            }

            return new ServiceResponse(true, "");
        }
    }
}