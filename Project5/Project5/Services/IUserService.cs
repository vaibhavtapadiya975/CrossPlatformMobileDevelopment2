using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.Models;

namespace Project5.Services
{
    public interface IUserService
    {
        Task<int> AddUser(User userModel);
        Task<int> DeleteUser(User userModel);
        Task<int> UpdateUser(User userModel);
        Task<User> GetUser(string email);
    }
}
