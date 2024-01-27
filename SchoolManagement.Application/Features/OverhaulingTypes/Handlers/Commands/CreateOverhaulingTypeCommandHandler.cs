using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OverhaulingType.Validators;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Handlers.Commands
{
    public class CreateOverhaulingTypeCommandHandler : IRequestHandler<CreateOverhaulingTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOverhaulingTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOverhaulingTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOverhaulingTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OverhaulingTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OverhaulingType = _mapper.Map<OverhaulingType>(request.OverhaulingTypeDto);

                OverhaulingType = await _unitOfWork.Repository<OverhaulingType>().Add(OverhaulingType);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OverhaulingType.OverhaulingTypeId;
            }

            return response;
        }
    }
}
