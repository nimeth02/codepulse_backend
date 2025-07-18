namespace codePuls.Application.DTOs.RequestDTOs
{
    public record class CreateProjectUsersRequestDto
    {

        public Guid ProjectId { get; init; }
        public UserRequestDto[] Users { get; init; }
    }
}
