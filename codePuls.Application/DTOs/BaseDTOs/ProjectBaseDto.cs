namespace codePuls.Application.DTOs.BaseDTOs
{
    public class ProjectBaseDto
    {
        public string ProjectName { get; set; }
        public string NodeId { get; set; }
        public string? AvatarUrl { get; set; }
        public string DisplayName { get; set; }
        public DateTime ProjectCreatedAt { get; set; }
        public DateTime ProjectUpdatedAt { get; set; }
    }
}
