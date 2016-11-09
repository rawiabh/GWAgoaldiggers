using GWA.Domaine.Entities;
using GWA.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Service.UserService.IService
{
    public interface IServiceUser : IService<User>
    {
        //IEnumerable<User> GetUserByRole(string Role);
        //IEnumerable<User> GetUserAuction(int idAuction);
        //int numberUserAuction(int idAuction);
        //void participateUserAuction(int idAuction, int idBayer);
    }
}
