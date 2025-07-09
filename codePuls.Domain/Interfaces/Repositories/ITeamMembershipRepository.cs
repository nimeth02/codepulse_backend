using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codePuls.Domain.Entities;

namespace codePuls.Domain.Interfaces.Repositories
{
    public interface ITeamMembershipRepository
    {
        Task<bool> CreateTeamMembershipAsync(List<TeamMember> memberships);
        Task<IEnumerable<User>> GetAllUserByTeamIdAsync(Guid TeamId);
    }
}
