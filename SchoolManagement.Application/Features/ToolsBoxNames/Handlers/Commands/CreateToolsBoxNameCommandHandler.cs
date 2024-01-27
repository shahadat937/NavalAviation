using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsBoxNames.Validators;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Handlers.Commands
{
    public class CreateToolsBoxNameCommandHandler : IRequestHandler<CreateToolsBoxNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateToolsBoxNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateToolsBoxNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateToolsBoxNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ToolsBoxNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ToolsBoxName = _mapper.Map<ToolsBoxName>(request.ToolsBoxNameDto);

                ToolsBoxName = await _unitOfWork.Repository<ToolsBoxName>().Add(ToolsBoxName);

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
                response.Id = ToolsBoxName.ToolsBoxNameId;
            }

            return response;
        }
    }
}
