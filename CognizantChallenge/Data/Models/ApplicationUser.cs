using CognizantChallenge.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserTaskSolution> UserTaskSolutions { get; set; }
    }
}
