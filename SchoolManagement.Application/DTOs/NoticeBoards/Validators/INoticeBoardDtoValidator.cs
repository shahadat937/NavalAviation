
using FluentValidation;
using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.DTOs.NoticeBoards.Validators
{
    public class INoticeBoardDtoValidator : AbstractValidator<INoticeBoardDto>
    {
        //public INoticeBoardDtoValidator()
        //{
        //    RuleFor(b => b.Name)
        //        .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        //}
    }
}
