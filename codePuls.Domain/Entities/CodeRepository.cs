using System.ComponentModel.DataAnnotations;
namespace codePuls.Domain.Entities
{
    public class  CodeRepository : AuditableEntity
    {
        public Guid CodeRepositoryId { get; private set; }

        [Required]
        [MaxLength(50)]
        public string NodeId { get; private set; }

        [Required]
        [MaxLength(100)]
        public string CodeRepositoryName { get;  set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get;  set; }

        [Required]
        public Guid ProjectId { get; private set; }
        public Project Project { get;  set; }= null!;
        public ICollection<CodeRepositoryContributor> Contributors { get;  set; } = new HashSet<CodeRepositoryContributor>();
        public ICollection<PullRequest> PullRequests { get;  set; } = new HashSet<PullRequest>();

        private CodeRepository() { }
        public CodeRepository(
            string nodeId,
            string codeRepositoryname,
            string fullName,
            Guid projectId)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentException("Organization ID cannot be empty.", nameof(projectId));

            CodeRepositoryId = Guid.NewGuid(); 
            NodeId = nodeId;
            CodeRepositoryName = codeRepositoryname;
            FullName = fullName;
            ProjectId = projectId;

        }

    }
}
