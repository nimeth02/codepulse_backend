using codePuls.Domain.Entities;
using codePuls.Infrastructure.Exeptions;
using codePuls.Infrastructure.Persistence;
using CodePuls.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codePuls.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetUserById", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(Guid id)
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetAllUsers", ex);
            }
        }

        public async Task<List<(string NodeId, Guid UserId)>> GetExistingUserNodeIdsAndUserIdsAsync(List<string> userNodeIds)
        {
            try
            {
                var existingNodeIdsAndUserIds = await _context.Users
                .Where(u => userNodeIds.Contains(u.NodeId))
                .Select(u => new { u.NodeId, u.UserId })
                .ToListAsync();

                return existingNodeIdsAndUserIds
                       .Select(x => (x.NodeId, x.UserId))
                       .ToList();
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetExistingUserNodeIdsAndUserIds", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllUserByProjectIdAsync(Guid projectId)
        {
            try
            {
                return await _context.ProjectMembers
                    .Where(p => p.ProjectId == projectId)
                    .Include(p => p.User)
                    .Select(p => p.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetAllUserByProjectId", ex);
            }
        }

        public async Task<IEnumerable<User>> CreateUsersAsync(User[] users)
        {
            try
            {
                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("CreateUsers", ex);
            }
        }
    }
}