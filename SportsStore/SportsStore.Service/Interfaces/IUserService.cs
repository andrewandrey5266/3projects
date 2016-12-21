using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;

namespace SportsStore.Service.Interfaces
{
    public interface IUserService
    {
        UserViewModel Authenticate(string name, string password);

        string Register(ProfileViewModel registryVM);
       
    }
}
