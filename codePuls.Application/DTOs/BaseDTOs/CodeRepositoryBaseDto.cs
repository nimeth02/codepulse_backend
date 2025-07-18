namespace codePuls.Application.DTOs.BaseDTOs
{
    public record class CodeRepositoryBaseDto
    {
        public string NodeId { get; init; }

        public string CodeRepositoryName { get; init; }

        public string FullName { get; init; }

        public Guid ProjectId { get; init; }
    }
}