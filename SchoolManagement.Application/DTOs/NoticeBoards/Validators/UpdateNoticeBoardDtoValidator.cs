using FluentValidation;
using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.DTOs.NoticeBoards.Validators
{
    public class UpdateNoticeBoardDtoValidator : AbstractValidator<CreateNoticeBoardDto>
    {
        public UpdateNoticeBoardDtoValidator()  
        {
            Include(new INoticeBoardDtoValidator());

            RuleFor(b => b.NoticeBoardId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
