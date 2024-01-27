using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Commands
{
    public class DeleteAirCraftNameCommandHandler : IRequestHandler<DeleteAirCraftNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAirCraftNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAirCraftNameCommand request, CancellationToken cancellationToken)
        {
            var AirCraftName = await _unitOfWork.Repository<AirCraftName>().Get(request.AirCraftNameId);

            if (AirCraftName == null)
                throw new NotFoundException(nameof(AirCraftName), request.AirCraftNameId);

            await _unitOfWork.Repository<AirCraftName>().Delete(AirCraftName);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
               
            

            return Unit.Value;
        }
    }
}
