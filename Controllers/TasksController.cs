﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.API.Models;
using Task.API.Services.Interfaces;
using Task.API.ViewModel.Requests;
using Task.API.ViewModel.Responses;

namespace Task.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseApiController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getTasksResponse = await taskService.GetTasks(UserID);

            if (!getTasksResponse.Success)
            {
                return UnprocessableEntity(getTasksResponse);
            }

            var tasksResponse = getTasksResponse.Tasks.ConvertAll(o => new TaskResponse { Id = o.Id, IsCompleted = o.IsCompleted, Name = o.Name, Ts = o.Ts });

            return Ok(tasksResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskRequest taskRequest)
        {
            var task = new TaskModel { IsCompleted = taskRequest.IsCompleted, Ts = taskRequest.Ts, Name = taskRequest.Name, UserId = UserID };

            var saveTaskResponse = await taskService.SaveTask(task);

            if (!saveTaskResponse.Success)
            {
                return UnprocessableEntity(saveTaskResponse);
            }

            var taskResponse = new TaskResponse { Id = saveTaskResponse.Task.Id, IsCompleted = saveTaskResponse.Task.IsCompleted, Name = saveTaskResponse.Task.Name, Ts = saveTaskResponse.Task.Ts };

            return Ok(taskResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteTaskResponse = await taskService.DeleteTask(id, UserID);
            if (!deleteTaskResponse.Success)
            {
                return UnprocessableEntity(deleteTaskResponse);
            }

            return Ok(deleteTaskResponse.TaskId);
        }
    }
}
