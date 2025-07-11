using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codePuls.Application.DTOs.BaseDTOs;

namespace codePuls.Application.DTOs.ResponseDTOs
{
    public class ProjectResponseDto:ProjectBaseDto
    {
        public Guid ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
