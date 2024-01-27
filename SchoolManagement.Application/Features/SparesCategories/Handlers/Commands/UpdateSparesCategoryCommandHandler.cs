using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SparesCategory.Validators;
using SchoolManagement.Application.Features.SparesCategories.Requests.Commands;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Commands
{
    public class UpdateSparesCategoryCommandHandler : IRequestHandler<UpdateSparesCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSparesCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSparesCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSparesCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SparesCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SparesCategory = await _unitOfWork.Repository<SparesCategory>().Get(request.SparesCategoryDto.SparesCategoryId);

            if (SparesCategory is null)
                throw new NotFoundException(nameof(SparesCategory), request.SparesCategoryDto.SparesCategoryId);

            _mapper.Map(request.SparesCategoryDto, SparesCategory);

            await _unitOfWork.Repository<SparesCategory>().Update(SparesCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
