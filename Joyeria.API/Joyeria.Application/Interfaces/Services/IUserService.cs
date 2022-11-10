
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Joyeria.Core.Models;
using System.Threading.Tasks;

namespace Joyeria.Core.Services
{
   public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);
       
        Task<User> CreateAsync(User createToUser);

        Task<User> UpdateAsync(User userToUpdate);
    }
}
