using System.ComponentModel.DataAnnotations;
using codePuls.Domain.Entities;

namespace codePuls.Domain.Entities
{
    public class PullRequest : AuditableEntity
    {
        public Guid PullRequestId { get; private set; }

        [Required]
        [MaxLength(50)]
        public string NodeId { get; private set; }
        [Required]
        public int Number { get; private set; }

        [Required]
        [MaxLength(20)]
        public string State { get;  set; } = null!;

        public int Commits { get;  set; }
        public int Additions { get;  set; }
        public int Deletions { get;  set; }
        public int ChangedFiles { get;  set; }

        [Required]
        public DateTime PRCreatedAt { get;  set; }

        [Required]
        public DateTime PRUpdatedAt { get;  set; }

        public DateTime? PRMergedAt { get;  set; }
        public DateTime? PRClosedAt { get;  set; }


        [Required]
        public Guid CodeRepositoryId { get; private set; }

        [Required]
        public Guid ProjectId { get; private set; }

        public Guid? UserId { get; private set; }

        public CodeRepository CodeRepository { get;  set; } = null!;
        public User User { get;  set; } = null!;

        public Project Project { get; set; } = null!;


        private PullRequest() { }

        public PullRequest(
            string nodeId,
            int number,
            string state,
            int commits,
            int additions,
            int deletions,
            int changedFiles,
            DateTime PRCreatedAt,
            DateTime PRUpdatedAt,
            DateTime?PRMergedAt,
            DateTime?PRClosedAt,
            Guid codeRepositoryId,
            Guid? userId,
            Guid projectId
            )
        {
            if (codeRepositoryId == Guid.Empty) throw new ArgumentException("Code Repository ID cannot be empty.", nameof(codeRepositoryId));
            //if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));
            PullRequestId = Guid.NewGuid();
            NodeId = nodeId;
            Number = number;
            State = state;
            Commits = commits;
            Additions = additions;
            Deletions = deletions;
            ChangedFiles = changedFiles;
            PRCreatedAt = PRCreatedAt;
            PRUpdatedAt = PRUpdatedAt;
            PRMergedAt = PRMergedAt;
            PRClosedAt = PRClosedAt;
            CodeRepositoryId = codeRepositoryId;
            UserId = userId;
            ProjectId = projectId;
        }

    }
}