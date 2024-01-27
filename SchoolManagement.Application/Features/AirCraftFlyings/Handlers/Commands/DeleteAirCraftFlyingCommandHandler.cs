using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Commands
{
    public class DeleteAirCraftFlyingCommandHandler : IRequestHandler<DeleteAirCraftFlyingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAirCraftFlyingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAirCraftFlyingCommand request, CancellationToken cancellationToken)
        {
            var AirCraftFlying = await _unitOfWork.Repository<AirCraftFlying>().Get(request.AirCraftFlyingId);

            if (AirCraftFlying == null)
                throw new NotFoundException(nameof(AirCraftFlying), request.AirCraftFlyingId);

            await _unitOfWork.Repository<AirCraftFlying>().Delete(AirCraftFlying);
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
