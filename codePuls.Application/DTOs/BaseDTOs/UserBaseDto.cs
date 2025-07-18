using System;
namespace codePuls.Application.DTOs.BaseDTOs
{
    public class UserBaseDto
    {
        public string UserName { get; set; }
        public string NodeId { get; set; }
        public string? AvatarUrl { get; set; }
        public string DisplayName { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public DateTime UserUpdatedAt { get; set; }
    }
}
