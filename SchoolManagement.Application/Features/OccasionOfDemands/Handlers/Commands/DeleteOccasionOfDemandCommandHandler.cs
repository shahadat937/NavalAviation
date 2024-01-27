using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Handlers.Commands
{
    public class DeleteOccasionOfDemandCommandHandler : IRequestHandler<DeleteOccasionOfDemandCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOccasionOfDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOccasionOfDemandCommand request, CancellationToken cancellationToken)
        {
            var OccasionOfDemand = await _unitOfWork.Repository<OccasionOfDemand>().Get(request.OccasionOfDemandId);

            if (OccasionOfDemand == null)
                throw new NotFoundException(nameof(OccasionOfDemand), request.OccasionOfDemandId);

            await _unitOfWork.Repository<OccasionOfDemand>().Delete(OccasionOfDemand);
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
