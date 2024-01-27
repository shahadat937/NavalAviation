using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PreviousItemStore.Validators;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PreviousItemStores.Handlers.Commands
{
    public class CreatePreviousItemStoreCommandHandler : IRequestHandler<CreatePreviousItemStoreCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePreviousItemStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePreviousItemStoreCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePreviousItemStoreDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PreviousItemStoreDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PreviousItemStore = _mapper.Map<PreviousItemStore>(request.PreviousItemStoreDto);

                PreviousItemStore = await _unitOfWork.Repository<PreviousItemStore>().Add(PreviousItemStore);
                PreviousItemStore.WarrantyStartDate = PreviousItemStore.WarrantyStartDate.Value.AddDays(1.0);
                PreviousItemStore.WarrantyEndDate = PreviousItemStore.WarrantyEndDate.Value.AddDays(1.0);
                PreviousItemStore.ItemReceivedDate = PreviousItemStore.ItemReceivedDate.Value.AddDays(1.0);
                PreviousItemStore.DemandDate = PreviousItemStore.DemandDate.Value.AddDays(1.0);
                PreviousItemStore.DateOfTenderFloat = PreviousItemStore.DateOfTenderFloat.Value.AddDays(1.0);
                PreviousItemStore.TenderopeningDate = PreviousItemStore.TenderopeningDate.Value.AddDays(1.0);
                PreviousItemStore.TenderPublishDate = PreviousItemStore.TenderPublishDate.Value.AddDays(1.0);
                PreviousItemStore.CalibrationDate = PreviousItemStore.CalibrationDate.Value.AddDays(1.0);
                PreviousItemStore.NextCalibrationDate = PreviousItemStore.NextCalibrationDate.Value.AddDays(1.0);
                
                await _unitOfWork.Save();
                


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PreviousItemStore.PreviousItemStoreId;
            }

            return response;
        }
    }
}
