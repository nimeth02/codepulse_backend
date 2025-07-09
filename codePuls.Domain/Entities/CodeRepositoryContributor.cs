using System.ComponentModel.DataAnnotations;

namespace codePuls.Domain.Entities
{
    public class CodeRepositoryContributor : AuditableEntity
    {
        [Required]
        public Guid CodeRepositoryId { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        public CodeRepository CodeRepository { get; set; } = null!;
        public User User { get; set; } = null!;

        private CodeRepositoryContributor() { }

        public CodeRepositoryContributor(Guid codeRepositoryId, Guid userId)
        {
            if (codeRepositoryId == Guid.Empty)
                throw new ArgumentException("RepositoryId ID cannot be empty.", nameof(codeRepositoryId));

            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            CodeRepositoryId = codeRepositoryId;
            UserId = userId;
        }
    }
}



