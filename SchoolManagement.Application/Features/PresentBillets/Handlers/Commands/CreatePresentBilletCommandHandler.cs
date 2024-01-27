using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PresentBillets.Validators;
using SchoolManagement.Application.Features.PresentBillets.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Commands
{
    public class CreatePresentBilletCommandHandler : IRequestHandler<CreatePresentBilletCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePresentBilletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePresentBilletCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePresentBilletDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PresentBilletDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PresentBillet = _mapper.Map<PresentBillet>(request.PresentBilletDto);

                PresentBillet = await _unitOfWork.Repository<PresentBillet>().Add(PresentBillet);

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
                response.Id = PresentBillet.PresentBilletId;
            }

            return response;
        }
    }
}
