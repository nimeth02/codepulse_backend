using codePuls.Application.DTOs.BaseDTOs;

namespace codePuls.Application.DTOs.ResponseDTOs
{
    public record class ProjectResponseDto:ProjectBaseDto
    {
        public Guid ProjectId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? LastModifiedAt { get; init; }
    }
}
