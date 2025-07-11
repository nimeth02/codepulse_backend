using System.ComponentModel.DataAnnotations;

namespace codePuls.Domain.Entities
{
    public class Project : AuditableEntity
    {
        public Guid ProjectId { get; private set; }

        [Required]
        [MaxLength(39)]  
        public string ProjectName { get; private set; }

        [Required]
        [MaxLength(50)]  
        public string NodeId { get; private set; }

        [MaxLength(255)]  
        public string? AvatarUrl { get;  set; }

        [Required]
        [MaxLength(100)]  
        public string DisplayName { get;  set; }

        [Required]  
        public DateTime ProjectCreatedAt { get; private set; }

        [Required]  
        public DateTime ProjectUpdatedAt { get;  set; }
        public ICollection<ProjectMember> Members { get;  set; } = new HashSet<ProjectMember>();
        public ICollection<Team> Teams { get;  set; } = new HashSet<Team>();

        public ICollection<CodeRepository> CodeRepositories { get;  set; } = new HashSet<CodeRepository>();

        public ICollection<PullRequest> PullRequests { get; set; } = new HashSet<PullRequest>();

        private Project() { }
        public Project(
          string projectName,
          string nodeId,
          string? avatarUrl,
          string displayName,
          DateTime projectCreatedAt,
          DateTime projectUpdatedAt)
        {
            ProjectId = Guid.NewGuid();
            ProjectName = projectName;
            NodeId = nodeId;
            AvatarUrl = avatarUrl;
            DisplayName = displayName;
            ProjectCreatedAt = projectCreatedAt;
            ProjectUpdatedAt = projectUpdatedAt;
        }

    }
}



