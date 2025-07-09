using System.ComponentModel.DataAnnotations;

namespace codePuls.Domain.Entities
{
    public class ProjectMember : AuditableEntity
    {
        [Required]
        public Guid ProjectId { get; private set; }

        [Required]
        public Guid UserId { get; private set; }
        public Project Project { get;  set; } = null!;
        public User User { get;  set; } = null!;

        private ProjectMember() { }

        public ProjectMember(Guid projectId, Guid userId)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentException("Organization ID cannot be empty.", nameof(projectId));

            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            ProjectId = projectId;
            UserId = userId;
        }
    }
}
