using CognizantChallenge.Data;
using CognizantChallenge.Data.Models;
using CognizantChallenge.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CognizantChallenge.Services
{
    public class TopUsersService: ITopUsersService
    {
        private readonly ApplicationDbContext _dbContext;
        public TopUsersService(ApplicationDbContext context) {
            _dbContext = context;
        }

        public List<TopUserView> GetTopUsers() {
            return _dbContext.TopUsers.OrderByDescending(x => x.TaskCount).Take(3).ToList();
        }
    }
}
