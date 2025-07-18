using codePuls.Application.DTOs.BaseDTOs;

namespace codePuls.Application.DTOs.ResponseDTOs
{
    public record class CodeRepositoryResponseDto : CodeRepositoryBaseDto
    {
        public Guid CodeRepositoryId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? LastModifiedAt { get; init; }
    }
}