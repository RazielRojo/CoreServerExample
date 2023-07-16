using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnotechExam.Models;
using InnotechExam.Modules;
using InnotechExam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnotechExam.Controllers
{

    #region Property  
   
    #endregion

    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskModule _taskModule;
        public TasksController(ITaskModule taskModule)
        {
            _taskModule = taskModule;
        }
        [HttpGet]
        [Route("api/[controller]/GetTaskTypes")]
        public async Task<IActionResult> GetTaskTypes()
        {
            var Types =  _taskModule.GetTaskTypes();
            return Ok(Types);
        }
        [HttpGet]
        [Route("api/[controller]/GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            var Types = _taskModule.GetTasks();
            return Ok(Types);
        }
        [HttpPost]
        [Route("api/[controller]/AddTask")]
        public async Task<IActionResult> AddTask([FromBody] TaskData taskData)
        {
            var res = _taskModule.AddTask(taskData);
            return Ok(res);
        }
        [HttpGet]
        [Route("api/[controller]/RemoveTask")]
        public async Task<IActionResult> RemoveTask()
        {
            var Types = _taskModule.GetTaskTypes();
            return Ok(Types);
        }
        [HttpGet]
        [Route("api/[controller]/RunTasks")]
        public async Task<IActionResult> RunTasks()
        {
            var Types = _taskModule.RunTasks();
            return Ok(Types);
        }
    }
}
