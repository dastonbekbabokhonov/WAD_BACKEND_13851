using WAD_BACKEND_13851.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WAD_BACKEND_13851.Repositories
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<Workout>> GetAllWorkouts();
        Task<Workout> GetWorkoutById(int id);
        Task CreateWorkout(Workout workout);    
        Task UpdateWorkout(Workout workout);
        Task DeleteWorkout(int id);
        bool WorkoutExists(int id);
    }
}
