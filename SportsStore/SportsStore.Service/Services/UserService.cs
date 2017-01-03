using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Context;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
using System.Security.Cryptography;
namespace SportsStore.Service.Services
{
    public class UserService : IUserService
    {
        EFDbContext context = new EFDbContext();

        public UserViewModel Authenticate(string logname, string password)
        {
            var hash = HashFunction(password);

            var user = context.Users
                .Where(i => i.Logname == logname && i.Password == hash)
                .FirstOrDefault();

            if (user == null)
                return null;

            return new UserViewModel(user.Id, user.IsAdmin) 
            {
                Email = user.Email, 
                Surname = user.Surname, 
                Name = user.Name 
            };

         }


        public string Register(ProfileViewModel r)
        {
            var alreadyExist = context.Users.Where(i => i.Logname == r.Logname).FirstOrDefault();
            if (alreadyExist != null)
                return "logname error";
            alreadyExist = context.Users.Where(i => i.Email == r.Email).FirstOrDefault();
            if (alreadyExist != null)
                return "email error";
            //only email check
            context.Users.Add(new User
            {
                Name = r.Name,
                Surname = r.Surname,
                Logname = r.Logname,
                Password = HashFunction(r.Password),
                Email = r.Email,
                IsAdmin = r.IsAdmin
            });

            context.SaveChanges();

            return "success";
        }
        private string HashFunction(string plainPassword)
        {
            byte[] bytepass = Encoding.ASCII.GetBytes(plainPassword);
         
            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.    
            return   new ASCIIEncoding().GetString(sha.ComputeHash(bytepass));
         
        }
        private string HashWithSaultFunction(string plainPassword)
        {
            return "";
        }
 
    }
}
