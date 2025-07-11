
using codePuls.Domain.Entities;

namespace codePuls.Domain.Interfaces.Repositories
{
    public interface IProjectMembershipRepository
    {
        Task<bool> CreateProjectMembershipAsync(List<ProjectMember> memberships);
        Task<List<Guid>> GetExistingMembershipNodeIdsAsync(Guid projectId, List<Guid> userNodeIds);
    }
}
