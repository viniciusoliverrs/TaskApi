using Task.API.Models;

namespace Task.API.ViewModel.Responses
{
    public class GetTasksResponse : BaseResponse
    {
        public List<TaskModel> Tasks { get; set; }
    }
}
