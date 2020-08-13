using CognizantChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.Services.Interfaces
{
    public interface ITopUsersService
    {
        List<TopUserView> GetTopUsers();
    }
}
