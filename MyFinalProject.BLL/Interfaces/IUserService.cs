using System;
using MyFinalProject.BLL.ViewModels.UserVM;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.Interfaces
{
    public interface IUserService
    {
        bool RegisterUser(AccountVM acc);
        bool LogIn(AccountVM acc);
    }
}
