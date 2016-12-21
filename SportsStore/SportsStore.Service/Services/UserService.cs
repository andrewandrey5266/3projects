using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Context;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
namespace SportsStore.Service.Services
{
    public class UserService : IUserService
    {
        EFDbContext context = new EFDbContext();

        public UserViewModel Authenticate(string logname, string password)
        {
            var user = context.Users
                .Where(i => i.Logname == logname && i.Password == password)
                .FirstOrDefault();

            if (user == null)
                return null;

            return new UserViewModel(user.Id, user.Name, user.IsAdmin);

         }


        public string Register(ProfileViewModel r)
        {
            //only email check
            context.Users.Add(new User
            {
                Name = r.Name,
                Surname = r.Surname,
                Logname = r.Logname,
                Password = r.Password,
                Email = r.Email,
                IsAdmin = r.IsAdmin
            });

            context.SaveChanges();

            return "success";
        }
    }
}
