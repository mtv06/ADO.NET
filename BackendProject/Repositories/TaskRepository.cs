using BackendProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DBTestContext _context;

        public TaskRepository(DBTestContext context)
        {
            _context = context;
        }

        public void AddTask(Models.Task task)
        {
            var TaskDate = new SqlParameter("TaskDate", task.TaskDate);
            var TaskNumber = new SqlParameter("TaskNumber", task.TaskNumber);
            var ClaimId = new SqlParameter("ClaimId", task.ClaimId);
            var BrigadeId = new SqlParameter("BrigadeId", task.BrigadeId);
            var TaskStaging = new SqlParameter("TaskStaging", task.TaskStaging);
            var BrigadeConfirmation = new SqlParameter("BrigadeConfirmation", task.BrigadeConfirmation);
            var BrigadeNote = new SqlParameter("BrigadeNote", task.BrigadeNote);
            var BrigadeMark = new SqlParameter("BrigadeMark", task.BrigadeMark);
            _context.Database.ExecuteSqlCommand("[dbo].[AddTask] @TaskDate, @TaskNumber, @ClaimId, @BrigadeId, @TaskStaging, @BrigadeConfirmation, @BrigadeNote, @BrigadeMark", TaskDate, TaskNumber, ClaimId, BrigadeId, TaskStaging, BrigadeConfirmation, BrigadeNote, BrigadeMark);
        }
    
        public IEnumerable<Models.Task> GetAllTask()
        {
            return _context.Task.FromSql("[dbo].[GetAllTask]");
        }

        public IEnumerable<Models.Task> GetTask(int Id)
        {
            var taskId = new SqlParameter("Id", Id);
            return _context.Task.FromSql("[dbo].[GetTask] @Id", taskId);
        }

        public void RemoveTask(int Id)
        {
            var taskId = new SqlParameter("Id", Id);
            _context.Database.ExecuteSqlCommand("[dbo].[RemoveTask] @Id", taskId);
        }

        public void UpdateTask(int Id, Models.Task task)
        {
            var taskId = new SqlParameter("Id", Id);
            var TaskDate = new SqlParameter("TaskDate", task.TaskDate);
            var TaskNumber = new SqlParameter("TaskNumber", task.TaskNumber);
            var ClaimId = new SqlParameter("ClaimId", task.ClaimId);
            var BrigadeId = new SqlParameter("BrigadeId", task.BrigadeId);
            var TaskStaging = new SqlParameter("TaskStaging", task.TaskStaging);
            var BrigadeConfirmation = new SqlParameter("BrigadeConfirmation", task.BrigadeConfirmation);
            var BrigadeNote = new SqlParameter("BrigadeNote", task.BrigadeNote);
            var BrigadeMark = new SqlParameter("BrigadeMark", task.BrigadeMark);
            _context.Database.ExecuteSqlCommand("[dbo].[UpdateTask] @Id, @TaskDate, @TaskNumber, @ClaimId, @BrigadeId, @TaskStaging, @BrigadeConfirmation, @BrigadeNote, @BrigadeMark", taskId, TaskDate, TaskNumber, ClaimId, BrigadeId, TaskStaging, BrigadeConfirmation, BrigadeNote, BrigadeMark);
        }

        public IEnumerable<TaskBrigadeForMonth> GetTaskBrigadeForMonth()
        {
            var TaskBrigadeForMonth = new List<TaskBrigadeForMonth>();
            _context.Database.OpenConnection();
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.TaskBrigadeForMonth";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    TaskBrigadeForMonth.Add(item: new TaskBrigadeForMonth
                    {
                        monthTask = reader["monthTask"].ToString(),
                        brigadeName = reader["brigadeName"].ToString(),
                        countTask = reader["countTask"].ToString(),
                    });
                }
            }
            return TaskBrigadeForMonth;
        }

    }
}
