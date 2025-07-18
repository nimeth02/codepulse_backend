
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Domain.Entities;

namespace codePuls.Application.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> GetProjectByIdAsync(Guid id);
        Task<IEnumerable<ProjectResponseDto>> GetAllProjectsAsync();
        Task<ProjectResponseDto> CreateProjectAsync(ProjectRequestDto project);
       



    }
}
