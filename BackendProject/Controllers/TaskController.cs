using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProject.Models;
using BackendProject.Repositories;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/Task
        [HttpGet]
        public IEnumerable<Models.Task> GetTask()
        {
            return _taskRepository.GetAllTask();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public IEnumerable<Models.Task> GetTask([FromRoute] int id)
        {
            return _taskRepository.GetTask(id);
        }

        // POST: api/Task
        [HttpPost]
        public void PostTask([FromBody] Models.Task task)
        {
            _taskRepository.AddTask(task);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public void DeleteTask([FromRoute] int id)
        {
            _taskRepository.RemoveTask(id);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public void PutTask([FromRoute] int id, [FromBody] Models.Task task)
        {
            _taskRepository.UpdateTask(id, task);
        }

        // GET: api/Task
        [HttpGet("report")]
        public IEnumerable<TaskBrigadeForMonth> GetTaskBrigadeForMonth()
        {
            return _taskRepository.GetTaskBrigadeForMonth();
        }
    }
}