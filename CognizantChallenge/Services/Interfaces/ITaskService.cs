using CognizantChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetTasks();
        Task<TaskSolutionResult> SubmitTaskSolution(TaskSolutionModel model, string currentUserId);
    }
}
