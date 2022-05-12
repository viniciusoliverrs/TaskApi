using Task.API.Models;

namespace Task.API.ViewModel.Responses
{
    public class SaveTaskResponse : BaseResponse
    {
        public TaskModel Task { get; set; }
    }
}
