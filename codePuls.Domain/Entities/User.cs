using System.ComponentModel.DataAnnotations;
namespace codePuls.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid UserId { get; private set; }

        [Required]
        [MaxLength(39)]  
        public string UserName { get; private set; }

        [Required]  
        public string NodeId { get; private set; }

        [MaxLength(255)] 
        public string? AvatarUrl { get; private set; }

        [MaxLength(100)]  
        public string DisplayName { get; private set; }

        [Required]
        public DateTime UserCreatedAt { get; private set; }

        [Required]
        public DateTime UserUpdatedAt { get; private set; }

        public ICollection<CodeRepositoryContributor> CodeRepositoryContributions { get;  set; } = new HashSet<CodeRepositoryContributor>();
        public ICollection<ProjectMember> ProjectMemberships { get;  set; }= new HashSet<ProjectMember>();
        public ICollection<TeamMember> TeamMemberships { get;  set; } = new HashSet<TeamMember>();
        public ICollection<PullRequest> PullRequests { get;  set; } = new HashSet<PullRequest>(); 


        private User() { } 

        public User(
            string login,
            string nodeId,
            string? avatarUrl,
            string displayName,
            DateTime userCreatedAt,
            DateTime userUpdatedAt)
        {
            UserId = Guid.NewGuid();
            UserName = login;
            NodeId = nodeId;
            AvatarUrl = avatarUrl;
            DisplayName = displayName;
            UserCreatedAt = userCreatedAt;
            UserUpdatedAt = userUpdatedAt;
        }

    }
}