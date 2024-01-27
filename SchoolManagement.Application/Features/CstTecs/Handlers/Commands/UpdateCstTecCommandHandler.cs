using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CstTec.Validators;
using SchoolManagement.Application.Features.CstTecs.Requests.Commands;

namespace SchoolManagement.Application.Features.CstTecs.Handlers.Commands
{
    public class UpdateCstTecCommandHandler : IRequestHandler<UpdateCstTecCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCstTecCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCstTecCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCstTecDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CstTecDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CstTec = await _unitOfWork.Repository<CstTec>().Get(request.CstTecDto.CstTecId);

            if (CstTec is null)
                throw new NotFoundException(nameof(CstTec), request.CstTecDto.CstTecId);

            _mapper.Map(request.CstTecDto, CstTec);

            await _unitOfWork.Repository<CstTec>().Update(CstTec);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
