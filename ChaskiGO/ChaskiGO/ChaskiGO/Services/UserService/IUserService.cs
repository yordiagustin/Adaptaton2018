using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Models;

namespace ChaskiGO.Services.UserService
{
    public interface IUserService
    {
        Task SaveUser(User user);
    }
}
