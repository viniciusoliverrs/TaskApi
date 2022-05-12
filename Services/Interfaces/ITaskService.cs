using Task.API.Models;
using Task.API.ViewModel.Responses;

namespace Task.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task<GetTasksResponse> GetTasks(int userId);
        Task<SaveTaskResponse> SaveTask(TaskModel task);
        Task<DeleteTaskResponse> DeleteTask(int taskId, int userId);
    }
}
