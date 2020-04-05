using AutoMapper;
using UrlShortener.Resources;
using UrlShortener.Domain.Model;


namespace UrlShortener.Mapping
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<UrlShortenerModel, UrlShortenerResource>();
            CreateMap<UserModel, UserResource>();
        }
        
    }
}