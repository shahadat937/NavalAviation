using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Courses.Validators;
using SchoolManagement.Application.Features.Courses.Requests.Commands;

namespace SchoolManagement.Application.Features.Courses.Handlers.Commands
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Course = await _unitOfWork.Repository<Course>().Get(request.CourseDto.CourseId);

            if (Course is null)
                throw new NotFoundException(nameof(Course), request.CourseDto.CourseId);

            _mapper.Map(request.CourseDto, Course);

            await _unitOfWork.Repository<Course>().Update(Course);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
