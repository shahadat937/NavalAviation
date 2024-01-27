using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PartOfShipments.Handlers.Commands
{
    public class DeletePartOfShipmentCommandHandler : IRequestHandler<DeletePartOfShipmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePartOfShipmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePartOfShipmentCommand request, CancellationToken cancellationToken)
        {
            var PartOfShipment = await _unitOfWork.Repository<PartOfShipment>().Get(request.PartOfShipmentId);

            if (PartOfShipment == null)
                throw new NotFoundException(nameof(PartOfShipment), request.PartOfShipmentId);

            await _unitOfWork.Repository<PartOfShipment>().Delete(PartOfShipment);
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
