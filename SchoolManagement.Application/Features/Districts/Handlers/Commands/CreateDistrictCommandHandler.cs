using AutoMapper;
using SchoolManagement.Application.DTOs.District.Validators;
using SchoolManagement.Application.Features.Districts.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Districts.Handlers.Commands
{
    public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDistrictCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDistrictDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DistrictDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Districts = _mapper.Map<District>(request.DistrictDto);

                Districts = await _unitOfWork.Repository<District>().Add(Districts);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Districts.DistrictId;
            }

            return response;
        }
    }
}
