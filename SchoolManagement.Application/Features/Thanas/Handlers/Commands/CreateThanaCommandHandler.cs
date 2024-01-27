using AutoMapper;
using SchoolManagement.Application.DTOs.Thana.Validators;
using SchoolManagement.Application.Features.Thanas.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Thanas.Handlers.Commands
{
    public class CreateThanaCommandHandler : IRequestHandler<CreateThanaCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateThanaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateThanaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateThanaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ThanaDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Thanas = _mapper.Map<Thana>(request.ThanaDto);

                Thanas = await _unitOfWork.Repository<Thana>().Add(Thanas);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Thanas.ThanaId;
            }

            return response;
        }
    }
}
