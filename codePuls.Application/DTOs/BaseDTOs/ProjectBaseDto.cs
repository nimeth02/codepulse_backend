namespace codePuls.Application.DTOs.BaseDTOs
{
    public record class ProjectBaseDto
    {
        public string ProjectName { get; init; }
        public string NodeId { get; init; }
        public string? AvatarUrl { get; init; }
        public string DisplayName { get; init; }
        public DateTime ProjectCreatedAt { get; init; }
        public DateTime ProjectUpdatedAt { get; init; }
    }
}
