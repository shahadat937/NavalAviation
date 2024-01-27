using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RunningHours.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Commands
{
    public class DeleteRunningHourCommandHandler : IRequestHandler<DeleteRunningHourCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRunningHourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRunningHourCommand request, CancellationToken cancellationToken)
        {
            var RunningHour = await _unitOfWork.Repository<RunningHour>().Get(request.RunningHourId);

            if (RunningHour == null)
                throw new NotFoundException(nameof(RunningHour), request.RunningHourId);

            await _unitOfWork.Repository<RunningHour>().Delete(RunningHour);
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
