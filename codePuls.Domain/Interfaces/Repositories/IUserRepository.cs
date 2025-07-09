using System.Threading.Tasks;
using codePuls.Domain.Entities;

namespace CodePuls.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync(Guid id);

        Task<IEnumerable<User>> CreateUsersAsync(User[] users);

        Task<IEnumerable<User>> GetAllUserByProjectIdAsync(Guid projectId);

        Task<List<(string NodeId, Guid UserId)>> GetExistingUserNodeIdsAndUserIdsAsync(List<string> userNodeIds);
    }
}