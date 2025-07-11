using codePuls.Domain.Entities;

namespace CodePuls.Domain.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<Project> GetProjectByNodeIdAsync(string nodeId);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> CreateProjectAsync(Project project);
    }
}