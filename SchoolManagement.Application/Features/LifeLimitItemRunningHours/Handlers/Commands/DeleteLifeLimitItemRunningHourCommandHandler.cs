using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Handlers.Commands
{
    public class DeleteLifeLimitItemRunningHourCommandHandler : IRequestHandler<DeleteLifeLimitItemRunningHourCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLifeLimitItemRunningHourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLifeLimitItemRunningHourCommand request, CancellationToken cancellationToken)
        {
            var LifeLimitItemRunningHour = await _unitOfWork.Repository<LifeLimitItemRunningHour>().Get(request.LifeLimitItemRunningHourId);

            if (LifeLimitItemRunningHour == null)
                throw new NotFoundException(nameof(LifeLimitItemRunningHour), request.LifeLimitItemRunningHourId);

            await _unitOfWork.Repository<LifeLimitItemRunningHour>().Delete(LifeLimitItemRunningHour);
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
