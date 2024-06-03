using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAD_BACKEND_13851.Data.Migrations;
using WAD_BACKEND_13851.Models;
using WAD_BACKEND_13851.Repositories;


namespace WAD_BACKEND_16232.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly FitnessTrackerDbContext _dbContext;

        public WorkoutRepository(FitnessTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Workout>> GetAllWorkouts()
        {
            try
            {
                return await _dbContext.Workouts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving workouts.", ex);
            }
        }

        public async Task<Workout> GetWorkoutById(int id)
        {
            try
            {
                return await _dbContext.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving workout with ID {id}.", ex);
            }
        }

        public async Task CreateWorkout(Workout workout)
        {
            if (workout == null)
            {
                throw new ArgumentNullException(nameof(workout));
            }

            try
            {
                _dbContext.Workouts.Add(workout);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create workout. Please check the provided data.", ex);
            }
        }

        public async Task UpdateWorkout(Workout workout)
        {
            if (workout == null)
            {
                throw new ArgumentNullException(nameof(workout));
            }

            try
            {
                _dbContext.Entry(workout).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating workout with ID {workout.Id}.", ex);
            }
        }

        public async Task DeleteWorkout(int id)
        {
            try
            {
                var workout = await _dbContext.Workouts.FirstOrDefaultAsync(w => w.Id == id);
                if (workout != null)
                {
                    _dbContext.Workouts.Remove(workout);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting workout with ID {id}.", ex);
            }
        }

        public bool WorkoutExists(int id)
        {
            return _dbContext.Workouts.Any(w => w.Id == id);
        }
    }
}
