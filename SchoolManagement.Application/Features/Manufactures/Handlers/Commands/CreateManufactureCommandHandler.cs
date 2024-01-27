using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Manufacture.Validators;
using SchoolManagement.Application.Features.Manufactures.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Manufactures.Handlers.Commands
{
    public class CreateManufactureCommandHandler : IRequestHandler<CreateManufactureCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateManufactureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateManufactureCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateManufactureDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ManufactureDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Manufacture = _mapper.Map<Manufacture>(request.ManufactureDto);

                Manufacture = await _unitOfWork.Repository<Manufacture>().Add(Manufacture);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Manufacture.ManufactureId;
            }

            return response;
        }
    }
}
