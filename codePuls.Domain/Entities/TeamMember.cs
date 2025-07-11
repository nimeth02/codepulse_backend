using System.ComponentModel.DataAnnotations;

namespace codePuls.Domain.Entities
{
    public class TeamMember : AuditableEntity
    {
        [Required]
        public Guid TeamId { get; private set; }
        [Required]
        public Guid UserId { get; private set; }
        public Team Team { get; set; } = null!;
        public User User { get;  set; } = null!;

        public TeamMember() { }

        public TeamMember(Guid teamId, Guid userId)
        {
            if (teamId == Guid.Empty) throw new ArgumentException("Team ID cannot be empty.", nameof(teamId));
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            TeamId = teamId;
            UserId = userId;
        }

    }
}




