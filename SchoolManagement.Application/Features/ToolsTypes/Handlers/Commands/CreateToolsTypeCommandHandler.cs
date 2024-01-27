using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsTypes.Validators;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsTypes.Handlers.Commands
{
    public class CreateToolsTypeCommandHandler : IRequestHandler<CreateToolsTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateToolsTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateToolsTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateToolsTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ToolsTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ToolsType = _mapper.Map<ToolsType>(request.ToolsTypeDto);

                ToolsType = await _unitOfWork.Repository<ToolsType>().Add(ToolsType);

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
                response.Id = ToolsType.ToolsTypeId;
            }

            return response;
        }
    }
}
