using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codePuls.Application.DTOs.RequestDTOs
{
    public record class CreateCodeRepositoriesDto
    {
        public Guid ProjectId { get; init; }
        public CodeRepositoryRequestDto[] CodeRepositories { get; init; }
    }
}
