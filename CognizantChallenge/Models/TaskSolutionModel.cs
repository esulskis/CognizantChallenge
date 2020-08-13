using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Models
{
    public class TaskSolutionModel
    {
        public int TaskId { get; set; }
        public string Solution { get; set; }
    }
}
