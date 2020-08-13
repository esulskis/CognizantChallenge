using CognizantChallenge.RextesterApiClient.Models;
using System.Threading.Tasks;

namespace CognizantChallenge.RextesterApiClient
{
    public interface IRextesterApiClient
    {
        Task<ExecuteCodeResponse> ExecuteCode(ExecuteCodeRequest request);
    }
}
