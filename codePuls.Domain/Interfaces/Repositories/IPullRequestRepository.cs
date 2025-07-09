using codePuls.Domain.Entities;

namespace CodePuls.Domain.Interfaces.Repositories
{
    public interface IPullRequestReository
    {
        //Task<PullRequest> GetByIdAsync(Guid id);
        //Task<IEnumerable<PullRequest>> GetAllAsync(Guid RepoId);
        Task<IEnumerable<PullRequest>> CreatePullRequestsAsync(List<PullRequest> pullRequests);
        Task<IEnumerable<String>> GetExistingPullRequestNodeIdsAsync(List<String> pullRequestNodeIds);
        
        Task<IEnumerable<PullRequest>> GetAllPullRequestsByCodeRepositoryIdAsync(Guid CodeRepositoryId);

        Task<PullRequest> GetLastPullRequestAsync(Guid codeRepositoryId);

        Task UpdatePullRequestsAsync(List<PullRequest> pullRequests);

        Task<List<(int Month, bool IsMerged, int Count)>> GetPullRequestByProjectIdAsync(Guid projectId, Guid teamId, int year);

        Task<List<(int Month, bool IsMerged, int Count)>> GetAbandonedPullRequestByProjectIdAsync(Guid projectId, Guid teamId, int year);

        Task<List<(int Month, int Count, double AverageCycleTimeInDays)>> GetCycleTimeByProjectIdAsync(Guid projectId,Guid teamId, int year);

        Task<PullRequest> GetExistingPullRequestNodeIdAsync(String pullRequestNodeIds);

        Task<List<(bool IsMerged, int Count)>> GetPullRequestsByTeamIdAsync(Guid projectId, Guid TeamId, int year);

        Task<List<(string user, int mergedCount, int notMergedCount, int totalCommits, int totalAdditions, int totalDeletions)>> GetPullRequestsByUsersAsync(Guid projectId, Guid teamId, int year);

        Task<List<(string team, int month, int MergedCount, int NotMergedCount)>> TeamPRClosedComparisonAsync(Guid projectId, int year);
        Task<List<(string team, int month, int Count, double AverageCycleTimeInDays)>> TeamICycleTimeComparisonAsync(Guid projectId, int year);

    }
}