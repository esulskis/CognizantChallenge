using CognizantChallenge.Data;
using CognizantChallenge.Data.Models;
using CognizantChallenge.Models;
using CognizantChallenge.RextesterApiClient;
using CognizantChallenge.RextesterApiClient.Models;
using CognizantChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Services
{
    public class TaskService:ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRextesterApiClient _rextesterApiClient;

        public TaskService(ApplicationDbContext context, IRextesterApiClient rextesterApiClient, UserManager<ApplicationUser> manager ) {
            _context = context;
            _rextesterApiClient = rextesterApiClient;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            return await _context.Tasks.Select(x=> new TaskModel { 
                TaskId = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }

        public async Task<TaskSolutionResult> SubmitTaskSolution(TaskSolutionModel model, string currentUserId){

            var taskSolutionResult = await ValidateTaskSolution(model);
            if (taskSolutionResult.IsSuccess)
            {
                await SaveTaskSolution(model, currentUserId);
            }

            return taskSolutionResult;
        }

        private async Task<TaskSolutionResult> ValidateTaskSolution(TaskSolutionModel taskSolution) {
            var task = _context.Tasks.First(x => x.Id == taskSolution.TaskId);
            var request = new ExecuteCodeRequest {Program = taskSolution.Solution, Input = task.Input};
            var response = await _rextesterApiClient.ExecuteCode(request);

            return new TaskSolutionResult
            {
                IsSuccess = response.IsSuccess && task.Output == response.Result.Trim(),
                Error = response.Errors
            };
        }

        private async System.Threading.Tasks.Task SaveTaskSolution(TaskSolutionModel model, string currentUserId)
        {
            if (_context.UserTaskSolutions.Any(x => x.TaskId == model.TaskId && x.UserId == currentUserId)) return;
            var userTaskSolution = new UserTaskSolution { TaskId = model.TaskId, Solution = model.Solution, UserId = currentUserId };
            _context.UserTaskSolutions.Add(userTaskSolution);
            await _context.SaveChangesAsync();
        }
    }
}
