using CognizantChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Data.Models
{
    public class UserTaskSolution
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string UserId { get; set; }
        public string Solution { get; set; }

        public Task Task { get; set; }
        public ApplicationUser User { get; set; }
    }
}
