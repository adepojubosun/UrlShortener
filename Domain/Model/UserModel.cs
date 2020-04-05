using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Domain.Model
{
    public class UserModel
    {
        public int Id {get; set; }
        public string FirstName {get; set;}

        public string LastName {get; set;}

        public string UserName {get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
 
}