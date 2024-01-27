using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandAuthority.Validators;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandAuthorities.Handlers.Commands
{
    public class CreateDemandAuthorityCommandHandler : IRequestHandler<CreateDemandAuthorityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandAuthorityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandAuthorityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandAuthorityDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DemandAuthority = _mapper.Map<DemandAuthority>(request.DemandAuthorityDto);

                DemandAuthority = await _unitOfWork.Repository<DemandAuthority>().Add(DemandAuthority);

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
                response.Id = DemandAuthority.DemandAuthorityId;
            }

            return response;
        }
    }
}
