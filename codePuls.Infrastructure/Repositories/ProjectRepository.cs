using codePuls.Domain.Entities;
using codePuls.Infrastructure.Exeptions;
using codePuls.Infrastructure.Persistence;
using CodePuls.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codePuls.Infrastructure.Repositories
{
    public class ProjectRepository(ApplicationDbContext context) : IProjectRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            try
            {
                return await _context.Projects.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetProjectById", ex);
            }
        }

        public async Task<Project> GetProjectByNodeIdAsync(string nodeId)
        {
            try
            {
                return await _context.Projects.FirstOrDefaultAsync(p => p.NodeId == nodeId);
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetProjectByNodeId", ex);
            }
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            try
            {
                return await _context.Projects.ToListAsync();
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("GetAllProjects", ex);
            }
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            try
            {
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (Exception ex)
            {
                throw RepositoryExceptionFactory.Create("CreateProject", ex);
            }
        }
    }
}