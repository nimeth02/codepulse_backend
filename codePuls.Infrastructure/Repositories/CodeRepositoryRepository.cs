using codePuls.Domain.Entities;
using codePuls.Infrastructure.Exeptions;
using codePuls.Infrastructure.Persistence;
using CodePuls.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codePuls.Infrastructure.Repositories
{
    public class CodeRepositoryRepository(ApplicationDbContext context) : ICodeReositoryReository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<CodeRepository>> GetAllByProjectIdAsync(Guid ProjectId)
        {
            try
            {
                return await _context.CodeRepositories
                     .Where(p => p.ProjectId == ProjectId)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetAllByProjectId", ex);
            }
        }

        public async Task<IEnumerable<CodeRepository>> CreateRepositoriesAsync(List<CodeRepository> codeRepositories)
        {
            try
            {
                await _context.CodeRepositories.AddRangeAsync(codeRepositories);
                await _context.SaveChangesAsync();
                return codeRepositories;
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("CreateRepositories", ex);
            }
        }

        public async Task<List<String>> GetExistingCodeRepositoryNodeIdsAsync(List<String> codeRepositoryNodeIds)
        {
            try
            {
                var existingNodeIds = await _context.CodeRepositories
                    .Where(c => codeRepositoryNodeIds.Contains(c.NodeId))
                    .Select(u => u.NodeId)
                    .ToListAsync();

                return existingNodeIds;
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetExistingCodeRepositoryNodeIds", ex);
            }
        }
    }
}