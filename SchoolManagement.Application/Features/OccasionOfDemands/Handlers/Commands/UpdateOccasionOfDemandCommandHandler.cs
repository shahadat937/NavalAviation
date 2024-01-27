using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.OccasionOfDemand.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Handlers.Commands
{
    public class UpdateOccasionOfDemandCommandHandler : IRequestHandler<UpdateOccasionOfDemandCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOccasionOfDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOccasionOfDemandCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOccasionOfDemandDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OccasionOfDemandDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var OccasionOfDemand = await _unitOfWork.Repository<OccasionOfDemand>().Get(request.OccasionOfDemandDto.OccasionOfDemandId);

            if (OccasionOfDemand is null)
                throw new NotFoundException(nameof(OccasionOfDemand), request.OccasionOfDemandDto.OccasionOfDemandId);

            _mapper.Map(request.OccasionOfDemandDto, OccasionOfDemand);

            await _unitOfWork.Repository<OccasionOfDemand>().Update(OccasionOfDemand);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
