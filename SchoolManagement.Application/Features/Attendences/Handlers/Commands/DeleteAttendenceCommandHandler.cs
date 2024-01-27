using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Attendences.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Attendences.Handlers.Commands
{
    public class DeleteAttendenceCommandHandler : IRequestHandler<DeleteAttendenceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAttendenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAttendenceCommand request, CancellationToken cancellationToken)
        {
            var Attendence = await _unitOfWork.Repository<Attendence>().Get(request.AttendenceId);

            if (Attendence == null)
                throw new NotFoundException(nameof(Attendence), request.AttendenceId);

            await _unitOfWork.Repository<Attendence>().Delete(Attendence);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
