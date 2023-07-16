
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnotechExam.Models
{
    public class TaskData
    {
        //this can be considered being an enum
        public int TaskType { get; set; }
        public string TaskName { get; set; }
        public string TaskInput { get; set; }
        public int TaskPriority { get; set; }
        public string Output { get; set; }
        public string FailureReason { get; set; }
        //this also shold be enum
        public string Status { get; set; }
    }
}
