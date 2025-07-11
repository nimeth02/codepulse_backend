using System.ComponentModel.DataAnnotations;

namespace codePuls.Domain.Entities
{
    public class Team : AuditableEntity
    {
        public Guid TeamId { get; private set; }

        [Required]
        [MaxLength(50)]
        public string NodeId { get; private set; }

        [Required]
        [MaxLength(100)]
        public string TeamName { get;  set; }

        [MaxLength(500)]
        public string? Description { get;  set; }

        [Required]
        public Guid ProjectId { get;  set; }

        public Project Project { get; private set; } = null!;

        public ICollection<TeamMember> Members { get;  set; } = new HashSet<TeamMember>();

        private Team() { }

        public Team(
            string nodeId,
            string teamName,
            string? description
            //Guid projectId

            )
        {
            //if (ProjectId == Guid.Empty)
            //    throw new ArgumentException("Project ID cannot be empty.", nameof(ProjectId));

            TeamId = Guid.NewGuid();
            NodeId = nodeId;
            TeamName = teamName;
            Description = description;
            //ProjectId = projectId;
        }
    }
}
