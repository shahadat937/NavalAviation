using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GseItemName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseItemNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.GseItemNames.Handlers.Commands
{
    public class UpdateGseItemNameCommandHandler : IRequestHandler<UpdateGseItemNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGseItemNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGseItemNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGseItemNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GseItemNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GseItemName = await _unitOfWork.Repository<GseItemName>().Get(request.GseItemNameDto.GseItemNameId);

            if (GseItemName is null)
                throw new NotFoundException(nameof(GseItemName), request.GseItemNameDto.GseItemNameId);

            _mapper.Map(request.GseItemNameDto, GseItemName);

            await _unitOfWork.Repository<GseItemName>().Update(GseItemName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
