using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PreviousItemStore.Validators;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands;

namespace SchoolManagement.Application.Features.PreviousItemStores.Handlers.Commands
{
    public class UpdatePreviousItemStoreCommandHandler : IRequestHandler<UpdatePreviousItemStoreCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePreviousItemStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePreviousItemStoreCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePreviousItemStoreDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PreviousItemStoreDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PreviousItemStore = await _unitOfWork.Repository<PreviousItemStore>().Get(request.PreviousItemStoreDto.PreviousItemStoreId);

            if (PreviousItemStore is null)
                throw new NotFoundException(nameof(PreviousItemStore), request.PreviousItemStoreDto.PreviousItemStoreId);

            _mapper.Map(request.PreviousItemStoreDto, PreviousItemStore);
            PreviousItemStore.WarrantyStartDate = PreviousItemStore.WarrantyStartDate.Value.AddDays(1.0);
            PreviousItemStore.WarrantyEndDate = PreviousItemStore.WarrantyEndDate.Value.AddDays(1.0);
            PreviousItemStore.ItemReceivedDate = PreviousItemStore.ItemReceivedDate.Value.AddDays(1.0);
            PreviousItemStore.DemandDate = PreviousItemStore.DemandDate.Value.AddDays(1.0);
            PreviousItemStore.DateOfTenderFloat = PreviousItemStore.DateOfTenderFloat.Value.AddDays(1.0);
            PreviousItemStore.TenderopeningDate = PreviousItemStore.TenderopeningDate.Value.AddDays(1.0);
            PreviousItemStore.TenderPublishDate = PreviousItemStore.TenderPublishDate.Value.AddDays(1.0);
            PreviousItemStore.CalibrationDate = PreviousItemStore.CalibrationDate.Value.AddDays(1.0);
            PreviousItemStore.NextCalibrationDate = PreviousItemStore.NextCalibrationDate.Value.AddDays(1.0);
            await _unitOfWork.Repository<PreviousItemStore>().Update(PreviousItemStore);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
