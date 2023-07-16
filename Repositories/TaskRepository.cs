using InnotechExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnotechExam.Repositories
{
    public interface ITaskRepository
    {
        public List<TaskType> GetTaskTypes();
        public List<TaskData> GetTasks();
        public bool SaveChanges(List<TaskData> updatedData);
        public TaskData FindTask(string taskname);
        public bool AddTask(TaskData taskData);
        public bool RemoveTask(string taskname);
    }
    public class TaskRepository:ITaskRepository
    {
        static List<TaskType> taskTypes;
        static List<TaskData> taskDatas;
        public TaskRepository()
        {
            taskTypes = new List<TaskType>();
            taskTypes.Add(new TaskType { Name = "CalulateExpression", Value = 1 });
            taskTypes.Add(new TaskType { Name = "PermutateString", Value = 2 });
            taskDatas = new List<TaskData>();
            taskDatas.Add(new TaskData { 
                TaskType = 1,
                TaskName = "Task #1", TaskPriority = 1,TaskInput = "3(15+11)" ,Status = "Idle" 
            });
            taskDatas.Add(new TaskData {
                TaskType =2 ,
                TaskName = "Task 2", TaskPriority = 2 ,TaskInput = "abc" ,Status = "Idle"
            });
        }
        public List<TaskType> GetTaskTypes()
        {
            return taskTypes;
        }
        public List<TaskData> GetTasks()
        {
            return taskDatas;
        }
        public bool SaveChanges(List<TaskData> updatedData)
        {
            taskDatas = updatedData;
            return true;
        }
        public bool AddTask(TaskData taskData)
        {
            taskData.TaskPriority = taskDatas.Count+1;
            taskDatas.Add(taskData);
            return true;
        }
        public TaskData FindTask(string taskname)
        {
            var fonudedTask = taskDatas.Find(t => t.TaskName == taskname);
            return fonudedTask;
        }
        public bool RemoveTask(string taskname)
        {
            var taskToDelete = FindTask(taskname);
            if (taskToDelete == null)
            {
                return false;
            }
            taskDatas.Remove(taskToDelete);
            return true;
        }

    }
}
