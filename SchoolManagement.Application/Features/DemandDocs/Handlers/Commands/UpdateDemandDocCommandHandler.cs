using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandDocs.Validators;
using SchoolManagement.Application.Features.DemandDocs.Requests.Commands;

namespace SchoolManagement.Application.Features.DemandDocs.Handlers.Commands
{
    public class UpdateDemandDocCommandHandler : IRequestHandler<UpdateDemandDocCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandDocCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandDocDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DemandDocDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DemandDoc = await _unitOfWork.Repository<DemandDoc>().Get(request.DemandDocDto.DemandDocId);

            if (DemandDoc is null)
                throw new NotFoundException(nameof(DemandDoc), request.DemandDocDto.DemandDocId);

            _mapper.Map(request.DemandDocDto, DemandDoc);

            await _unitOfWork.Repository<DemandDoc>().Update(DemandDoc);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
