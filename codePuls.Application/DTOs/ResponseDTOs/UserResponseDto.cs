using codePuls.Application.DTOs.BaseDTOs;

namespace codePuls.Application.DTOs.ResponseDTOs
{
    public record class UserResponseDto : UserBaseDto
    {
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? LastModifiedAt { get; init; }
    }
}
