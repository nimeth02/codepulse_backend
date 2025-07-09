using codePuls.Domain.Entities;

namespace CodePuls.Domain.Interfaces.Repositories
{

    public interface ICodeReositoryReository
    {
        //Task<CodeRepository> GetByIdAsync(Guid id);
        Task<IEnumerable<CodeRepository>> GetAllByProjectIdAsync(Guid ProjectId);

        Task<IEnumerable<CodeRepository>> CreateRepositoriesAsync(List<CodeRepository> codeRepositories);
        Task<List<String>> GetExistingCodeRepositoryNodeIdsAsync(List<String> codeRepositoryNodeIds);


        
    }
}