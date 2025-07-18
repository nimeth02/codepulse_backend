namespace codePuls.Application.DTOs.BaseDTOs
{
    public record class UserBaseDto
    {
        public string UserName { get; init; }
        public string NodeId { get; init; }
        public string? AvatarUrl { get; init; }
        public string DisplayName { get; init; }
        public DateTime UserCreatedAt { get; init; }
        public DateTime UserUpdatedAt { get; init; }
    }
}