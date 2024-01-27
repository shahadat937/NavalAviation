using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EndLifeTypes.Validators;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.EndLifeTypes.Handlers.Commands
{
    public class CreateEndLifeTypeCommandHandler : IRequestHandler<CreateEndLifeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEndLifeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEndLifeTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEndLifeTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EndLifeTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var EndLifeType = _mapper.Map<EndLifeType>(request.EndLifeTypeDto);

                EndLifeType = await _unitOfWork.Repository<EndLifeType>().Add(EndLifeType);

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
                response.Id = EndLifeType.EndLifeTypeId;
            }

            return response;
        }
    }
}
