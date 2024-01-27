using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsLocation.Validators;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsLocations.Handlers.Commands
{
    public class CreateToolsLocationCommandHandler : IRequestHandler<CreateToolsLocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateToolsLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateToolsLocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateToolsLocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ToolsLocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ToolsLocation = _mapper.Map<ToolsLocation>(request.ToolsLocationDto);

                ToolsLocation = await _unitOfWork.Repository<ToolsLocation>().Add(ToolsLocation);
               
                    await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ToolsLocation.ToolsLocationId;
            }

            return response;
        }
    }
}
