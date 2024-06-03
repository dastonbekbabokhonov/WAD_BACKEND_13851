using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAD_BACKEND_13851.Models;

namespace WAD_BACKEND_13851.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsers(bool includeWorkouts = false);
        Task<Users> GetUserById(int id, bool includeWorkouts = false);
        Task CreateUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
        bool UserExists(int id);
        Task LoadUserWorkouts(Users user);
    }
}
