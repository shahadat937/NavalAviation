using FluentValidation;
using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.DTOs.NoticeBoards.Validators
{
    public class CreateNoticeBoardDtoValidator : AbstractValidator<CreateNoticeBoardDto>
    {
        public CreateNoticeBoardDtoValidator()
        {
            Include(new INoticeBoardDtoValidator());
        }
    }
} 
