namespace UrlShortener.Domain.Service
{
    public class ServiceResponse
    {
        public bool success {get; set;}
        public string message {get; set;}

        public ServiceResponse(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
    }
}