using codePuls.Application.DTOs;
using codePuls.Application.DTOs.RequestDTOs;
using codePuls.Application.DTOs.ResponseDTOs;
using codePuls.Domain.Entities;

namespace codePuls.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(Guid id);

        Task<IEnumerable<UserResponseDto>> CreateUsersAsync(Guid projectId, UserRequestDto[] users);

        Task<IEnumerable<UserResponseDto>> GetAllUserByProjectIdAsync(Guid projectId);
    }
}
