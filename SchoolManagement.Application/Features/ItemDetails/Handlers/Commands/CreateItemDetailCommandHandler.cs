using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemDetail.Validators;
using SchoolManagement.Application.Features.ItemDetails.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Commands
{
    public class CreateItemDetailCommandHandler : IRequestHandler<CreateItemDetailCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateItemDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateItemDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemDetailDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ItemDetail = _mapper.Map<ItemDetail>(request.ItemDetailDto);
                ItemDetail.VerificationCompletStatus = 0;
                ItemDetail = await _unitOfWork.Repository<ItemDetail>().Add(ItemDetail);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ItemDetail.ItemDetailId;
            }

            return response;
        }
    }
}
