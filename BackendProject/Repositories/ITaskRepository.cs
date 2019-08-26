using BackendProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Task> GetTask(int Id);
        IEnumerable<Models.Task> GetAllTask();
        void AddTask(Models.Task task);
        void UpdateTask(int Id, Models.Task task);
        void RemoveTask(int Id);
        IEnumerable<TaskBrigadeForMonth> GetTaskBrigadeForMonth();
    }
}
