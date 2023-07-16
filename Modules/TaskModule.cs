
using InnotechExam.BL;
using InnotechExam.Models;
using InnotechExam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnotechExam.Modules
{
    public interface ITaskModule
    {
        public IEnumerable<TaskType> GetTaskTypes();
        public IEnumerable<TaskData> GetTasks();
        public bool RunTasks();
        public bool AddTask(TaskData taskData);
        public bool RemoveTask(string taskname);
    }
    public class TaskModule: ITaskModule
    {
        private ITaskRepository _taskRepository;
        public TaskModule(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public IEnumerable<TaskType> GetTaskTypes()
        {
            var TypeList = _taskRepository.GetTaskTypes();
            return TypeList;
        }
        public IEnumerable<TaskData> GetTasks()
        {
            var taskList = _taskRepository.GetTasks();
            return taskList;
        }
        public bool RunTasks()
        {
            var taskList = _taskRepository.GetTasks().OrderBy(t=> t.TaskPriority).ToList();
            taskList.ForEach(t =>{
                try
                {
                    if (t.TaskType == 1)
                    {
                        t.Output = ActionBL.Calculate(t.TaskInput);
                    }
                    else if (t.TaskType == 2)
                    {
                        t.Output = ActionBL.PerMute(t.TaskInput.ToCharArray());
                    }
                    t.Status = "succees";
                }
                catch (Exception ex)
                {

                    t.FailureReason = ex.Message;
                    t.Status = "failed";
                }
               
            });

            _taskRepository.SaveChanges(taskList);
            return true;
        }
        public bool AddTask(TaskData taskData)
        {
            return _taskRepository.AddTask(taskData);
        }
        public bool RemoveTask(string taskname)
        {
            return _taskRepository.RemoveTask(taskname);
        }
    }
}
