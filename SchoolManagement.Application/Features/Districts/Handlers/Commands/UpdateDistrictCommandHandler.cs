using AutoMapper;
using SchoolManagement.Application.DTOs.District.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Districts.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Districts.Handlers.Commands
{
    public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDistrictCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDistrictDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DistrictDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Districts = await _unitOfWork.Repository<District>().Get(request.DistrictDto.DistrictId);

            if (Districts is null)
                throw new NotFoundException(nameof(District), request.DistrictDto.DistrictId);

            _mapper.Map(request.DistrictDto, Districts);

            await _unitOfWork.Repository<District>().Update(Districts);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
