using AutoMapper;
using SchoolManagement.Application.DTOs.Division.Validators;
using SchoolManagement.Application.Features.Divisions.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Divisions.Handlers.Commands
{
    public class CreateDivisionCommandHandler : IRequestHandler<CreateDivisionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDivisionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDivisionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDivisionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DivisionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Divisions = _mapper.Map<Division>(request.DivisionDto);

                Divisions = await _unitOfWork.Repository<Division>().Add(Divisions);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Divisions.DivisionId;
            }

            return response;
        }
    }
}
