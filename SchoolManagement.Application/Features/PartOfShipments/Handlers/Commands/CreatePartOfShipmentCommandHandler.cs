using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PartOfShipment.Validators;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PartOfShipments.Handlers.Commands
{
    public class CreatePartOfShipmentCommandHandler : IRequestHandler<CreatePartOfShipmentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePartOfShipmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePartOfShipmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePartOfShipmentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PartOfShipmentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PartOfShipment = _mapper.Map<PartOfShipment>(request.PartOfShipmentDto);

                PartOfShipment = await _unitOfWork.Repository<PartOfShipment>().Add(PartOfShipment);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PartOfShipment.PartOfShipmentId;
            }

            return response;
        }
    }
}
