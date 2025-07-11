using codePuls.Application.DTOs.RequestDTOs;
using FluentValidation;

namespace codePuls.Application.DTOs.RequestValidators
{
    public class ProjectRequestValidator: AbstractValidator<ProjectRequestDto>
    {
        public ProjectRequestValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(100).WithMessage("Project name must be ≤ 100 characters.");

            RuleFor(x => x.NodeId)
                .NotEmpty().WithMessage("Node ID is required.");

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("Display name is required.")
                .MaximumLength(50).WithMessage("Display name must be ≤ 50 characters.");

            RuleFor(x => x.ProjectCreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Creation date cannot be in the future.");

            RuleFor(x => x.ProjectUpdatedAt)
                .GreaterThanOrEqualTo(x => x.ProjectCreatedAt)
                .WithMessage("Update date must be after creation date.");
        }
    }
}
