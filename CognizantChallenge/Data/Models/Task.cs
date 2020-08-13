using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Data.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }

        public ICollection<UserTaskSolution> UserTaskSolutions { get; set; }
    }
}
