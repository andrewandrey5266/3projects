using System.Web.Security;

namespace SportsStore.WebUI.Models
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            //obsolete
            bool result = FormsAuthentication.Authenticate(username, password); 
            //bool result = Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}