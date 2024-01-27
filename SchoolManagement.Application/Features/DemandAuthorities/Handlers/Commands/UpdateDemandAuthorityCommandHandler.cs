using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandAuthority.Validators;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands;

namespace SchoolManagement.Application.Features.DemandAuthorities.Handlers.Commands
{
    public class UpdateDemandAuthorityCommandHandler : IRequestHandler<UpdateDemandAuthorityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandAuthorityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandAuthorityDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DemandAuthorityDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DemandAuthority = await _unitOfWork.Repository<DemandAuthority>().Get(request.DemandAuthorityDto.DemandAuthorityId);

            if (DemandAuthority is null)
                throw new NotFoundException(nameof(DemandAuthority), request.DemandAuthorityDto.DemandAuthorityId);

            _mapper.Map(request.DemandAuthorityDto, DemandAuthority);

            await _unitOfWork.Repository<DemandAuthority>().Update(DemandAuthority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
