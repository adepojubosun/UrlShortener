using System;
using System.Linq;
using UrlShortener.Domain.Model;
using UrlShortener.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Helpers;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModel> AuthenticateUser(string userName, string password)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user =  await _context.Users.SingleOrDefaultAsync(us => us.UserName == userName);

            if(user == null)
            {
                return null;
            }

            if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<UserModel> Create(UserModel user, string password)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }
            
            if(string.IsNullOrEmpty(password))
            {
                throw new AppException("Password is missing");
            }

            if(_context.Users.Any(us => us.UserName == user.UserName))
            {
                throw new AppException("Username is already taken");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _context.Users.Add(user);
           await _context.SaveChangesAsync();

            return user;
        }

        public async Task Update(UserModel user, string password = null)
        {
            throw new System.NotImplementedException();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or whitespace", "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or whitespace", "password");
            }

            if(storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of stored password hash (64 required)", "storedHash");
            }

            if(storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of stored password salt (128 Required)", "storedSalt");
            }

            using(var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var provPasswordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(var i = 0; i<storedHash.Length; i++)
                {
                    if(storedHash[i] != provPasswordhash[i])
                    {
                        return false;
                    }
                }
            }
            return true; 
        }

        public UserModel GetById(int Id)
        {
            return _context.Users.Find(Id);
        }
    }
}