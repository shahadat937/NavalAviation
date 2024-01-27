using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandStatuses.Handlers.Commands
{
    public class DeleteDemandStatusCommandHandler : IRequestHandler<DeleteDemandStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandStatusCommand request, CancellationToken cancellationToken)
        {
            var DemandStatus = await _unitOfWork.Repository<DemandStatus>().Get(request.DemandStatusId);

            if (DemandStatus == null)
                throw new NotFoundException(nameof(DemandStatus), request.DemandStatusId);

            await _unitOfWork.Repository<DemandStatus>().Delete(DemandStatus);
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
