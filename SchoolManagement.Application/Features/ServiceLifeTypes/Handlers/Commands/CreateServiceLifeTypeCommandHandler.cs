using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ServiceLifeTypes.Validators;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Handlers.Commands
{
    public class CreateServiceLifeTypeCommandHandler : IRequestHandler<CreateServiceLifeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateServiceLifeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateServiceLifeTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateServiceLifeTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ServiceLifeTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ServiceLifeType = _mapper.Map<ServiceLifeType>(request.ServiceLifeTypeDto);

                ServiceLifeType = await _unitOfWork.Repository<ServiceLifeType>().Add(ServiceLifeType);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ServiceLifeType.ServiceLifeTypeId;
            }

            return response;
        }
    }
}
