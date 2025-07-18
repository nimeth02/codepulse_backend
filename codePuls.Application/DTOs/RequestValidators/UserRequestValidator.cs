using codePuls.Application.DTOs.BaseDTOs;
using codePuls.Application.DTOs.RequestDTOs;
using FluentValidation;
using System;

namespace codePuls.Application.DTOs.RequestValidators
{
    public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
    {
        public UserRequestDtoValidator()
        {

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("GitHub username is required");


            RuleFor(x => x.NodeId)
                .NotEmpty().WithMessage("Node ID is required");


            RuleFor(x => x.AvatarUrl)
                .Must(uri => uri == null || Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Avatar URL must be valid when provided")
                .When(x => !string.IsNullOrEmpty(x.AvatarUrl));

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("Display name is required");


            RuleFor(x => x.UserCreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Creation date cannot be in the future");


            RuleFor(x => x.UserUpdatedAt)
                .GreaterThanOrEqualTo(x => x.UserCreatedAt)
                .WithMessage("Update date must be after creation date");

        }
    }
}