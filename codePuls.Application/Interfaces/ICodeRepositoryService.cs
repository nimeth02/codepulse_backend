using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;

namespace codePuls.Application.Interfaces
{
    public interface ICodeRepositoryService
    {
        Task<IEnumerable<CodeRepositoryResponseDto>> GetAllByProjectIdAsync(Guid ProjectId);
        Task<IEnumerable<CodeRepositoryResponseDto>> CreateRepositoriesAsync(Guid projectId, CodeRepositoryRequestDto[] codeRepositories);


    }
}
