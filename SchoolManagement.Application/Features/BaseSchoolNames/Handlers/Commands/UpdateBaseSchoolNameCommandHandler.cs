using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BaseSchoolNames.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BaseSchoolNames.Handlers.Commands
{  
    public class UpdateBaseSchoolNameCommandHandler : IRequestHandler<UpdateBaseSchoolNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateBaseSchoolNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateBaseSchoolNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBaseSchoolNameDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.BaseSchoolNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var BaseSchoolName = await _unitOfWork.Repository<BaseSchoolName>().Get(request.BaseSchoolNameDto.BaseSchoolNameId); 

            if (BaseSchoolName is null)  
                throw new NotFoundException(nameof(BaseSchoolName), request.BaseSchoolNameDto.BaseSchoolNameId); 

            _mapper.Map(request.BaseSchoolNameDto, BaseSchoolName);  

            await _unitOfWork.Repository<BaseSchoolName>().Update(BaseSchoolName); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}