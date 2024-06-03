using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_BACKEND_13851.Data.Migrations;
using WAD_BACKEND_13851.Models;

namespace WAD_BACKEND_13851.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FitnessTrackerDbContext _dbContext;

        public UsersRepository(FitnessTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Users>> GetAllUsers(bool includeWorkouts = false)
        {
            try
            {
                if (includeWorkouts)
                {
                    return await _dbContext.Users.Include(u => u.Workout).ToListAsync();
                }
                else
                {
                    return await _dbContext.Users.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error occurred while retrieving users.", ex);
            }
        }

        public async Task<Users> GetUserById(int id, bool includeWorkouts = false)
        {
            try
            {
                if (includeWorkouts)
                {
                    return await _dbContext.Users.Include(u => u.Workout).FirstOrDefaultAsync(u => u.Id == id);
                }
                else
                {
                    return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while retrieving user with ID {id}.", ex);
            }
        }

        public async Task CreateUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Failed to create user. Please check the provided data.", ex);
            }
        }

        public async Task UpdateUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while updating user with ID {user.Id}.", ex);
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"User with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while deleting user with ID {id}.", ex);
            }
        }

        public bool UserExists(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }

        public async Task LoadUserWorkouts(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                await _dbContext.Entry(user).Reference(u => u.Workout).LoadAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while loading workouts for user ID {user.Id}.", ex);
            }
        }
    }
}
