using codePuls.Domain.Entities;

namespace CodePuls.Domain.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        //Task<Team> GetByIdAsync(Guid id);
        Task<IEnumerable<Team>> GetAllTeamsByProjectIdAsync(Guid ProjectId);

        Task<IEnumerable<Team>> CreateTeamsAsync(List<Team> teams);
    }
}