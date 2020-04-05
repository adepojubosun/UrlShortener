using System;

namespace UrlShortener.Resources
{
    public class UrlShortenerResource
    {
        public string ShortUrl {get; set;}

        public string LongUrl {get; set;}

        public DateTime CreatedDate {get; set;}
        
        public DateTime ExpiredDate {get; set;}

    }
    
}