using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Courses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Courses.Handlers.Commands
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var Course = await _unitOfWork.Repository<Course>().Get(request.CourseId);

            if (Course == null)
                throw new NotFoundException(nameof(Course), request.CourseId);

            await _unitOfWork.Repository<Course>().Delete(Course);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
