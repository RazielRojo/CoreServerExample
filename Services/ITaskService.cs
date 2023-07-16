using InnotechExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnotechExam.Services
{
    public interface ITaskService
    {
        public Task<bool> AddTask(TaskData taskData);
    }
}
