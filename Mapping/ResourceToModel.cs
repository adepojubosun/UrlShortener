using AutoMapper;
using UrlShortener.Domain.Model;
using UrlShortener.Resources;

namespace UrlShortener.Mapping
{
    public class ResourceToModel : Profile
    {
        public ResourceToModel()
        {
            CreateMap<UserResource, UserModel>();
        }
        
    }
}