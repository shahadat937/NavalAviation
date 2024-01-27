using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OccasionOfDemand.Validators;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Handlers.Commands
{
    public class CreateOccasionOfDemandCommandHandler : IRequestHandler<CreateOccasionOfDemandCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOccasionOfDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOccasionOfDemandCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOccasionOfDemandDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OccasionOfDemandDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OccasionOfDemand = _mapper.Map<OccasionOfDemand>(request.OccasionOfDemandDto);

                OccasionOfDemand = await _unitOfWork.Repository<OccasionOfDemand>().Add(OccasionOfDemand);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OccasionOfDemand.OccasionOfDemandId;
            }

            return response;
        }
    }
}
