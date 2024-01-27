using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PlaceOfDelivery.Validators;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Handlers.Commands
{
    public class CreatePlaceOfDeliveryCommandHandler : IRequestHandler<CreatePlaceOfDeliveryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePlaceOfDeliveryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePlaceOfDeliveryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePlaceOfDeliveryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PlaceOfDeliveryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PlaceOfDelivery = _mapper.Map<PlaceOfDelivery>(request.PlaceOfDeliveryDto);

                PlaceOfDelivery = await _unitOfWork.Repository<PlaceOfDelivery>().Add(PlaceOfDelivery);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PlaceOfDelivery.PlaceOfDeliveryId;
            }

            return response;
        }
    }
}
