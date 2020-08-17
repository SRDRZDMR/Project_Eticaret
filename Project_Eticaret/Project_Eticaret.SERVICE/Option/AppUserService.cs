using Project_Eticaret.MODEL.Entities;
using Project_Eticaret.MODEL.Mapping;
using Project_Eticaret.SERVICE.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.SERVICE.Option
{
    public class AppUserService : BaseService<AppUser>
    {
        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.UserName == userName && x.Password == password); 
        }

        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }
    }
}
