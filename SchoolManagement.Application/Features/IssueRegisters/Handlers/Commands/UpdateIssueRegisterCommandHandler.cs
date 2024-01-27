using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Commands
{
    public class UpdateIssueRegisterCommandHandler : IRequestHandler<UpdateIssueRegisterCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateIssueRegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIssueRegisterCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIssueRegisterDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.IssueRegisterDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var IssueRegister = await _unitOfWork.Repository<IssueRegister>().Get(request.IssueRegisterDto.IssueRegisterId);

            if (IssueRegister is null)
                throw new NotFoundException(nameof(IssueRegister), request.IssueRegisterDto.IssueRegisterId);

            _mapper.Map(request.IssueRegisterDto, IssueRegister);

            await _unitOfWork.Repository<IssueRegister>().Update(IssueRegister);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
