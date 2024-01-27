using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Handlers.Commands
{
    public class DeletePlaceOfDeliveryCommandHandler : IRequestHandler<DeletePlaceOfDeliveryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePlaceOfDeliveryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePlaceOfDeliveryCommand request, CancellationToken cancellationToken)
        {
            var PlaceOfDelivery = await _unitOfWork.Repository<PlaceOfDelivery>().Get(request.PlaceOfDeliveryId);

            if (PlaceOfDelivery == null)
                throw new NotFoundException(nameof(PlaceOfDelivery), request.PlaceOfDeliveryId);

            await _unitOfWork.Repository<PlaceOfDelivery>().Delete(PlaceOfDelivery);
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
