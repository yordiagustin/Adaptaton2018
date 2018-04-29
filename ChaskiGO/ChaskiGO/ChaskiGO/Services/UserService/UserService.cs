using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChaskiGO.Models;

namespace ChaskiGO.Services.UserService
{
    public class UserService : IUserService
    {
        public async Task SaveUser(User user)
        {
            if (user != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<User>();
                    await tabla.InsertAsync(user);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
