using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codePuls.Application.DTOs.RequestDTOs;
using FluentValidation;

namespace codePuls.Application.DTOs.RequestValidators
{
    public class CodeRepositoryRequestValidator: AbstractValidator<CodeRepositoryRequestDto>
    {
        public CodeRepositoryRequestValidator()
        {
            RuleFor(x => x.NodeId)
                .NotEmpty().WithMessage("Node ID is required");

            RuleFor(x => x.CodeRepositoryName)
                .NotEmpty().WithMessage("Repository name is required");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required");

        }
    }
}
