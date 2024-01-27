using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LifeLimitItem.Validators;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItems.Handlers.Commands
{
    public class CreateLifeLimitItemCommandHandler : IRequestHandler<CreateLifeLimitItemCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLifeLimitItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLifeLimitItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLifeLimitItemDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LifeLimitItemDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var LifeLimitItem = _mapper.Map<LifeLimitItem>(request.LifeLimitItemDto);

                LifeLimitItem = await _unitOfWork.Repository<LifeLimitItem>().Add(LifeLimitItem);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = LifeLimitItem.LifeLimitItemId;
            }

            return response;
        }
    }
}
