using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Commands
{
    public class UpdateDailyAirworthinessFromCategoryCommandHandler : IRequestHandler<UpdateDailyAirworthinessFromCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDailyAirworthinessFromCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDailyAirworthinessFromCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDailyAirworthinessFromCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DailyAirworthinessFromCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DailyAirworthinessFromCategory = await _unitOfWork.Repository<DailyAirworthinessFromCategory>().Get(request.DailyAirworthinessFromCategoryDto.DailyAirworthinessFromCategoryId);

            if (DailyAirworthinessFromCategory is null)
                throw new NotFoundException(nameof(DailyAirworthinessFromCategory), request.DailyAirworthinessFromCategoryDto.DailyAirworthinessFromCategoryId);

            _mapper.Map(request.DailyAirworthinessFromCategoryDto, DailyAirworthinessFromCategory);

            await _unitOfWork.Repository<DailyAirworthinessFromCategory>().Update(DailyAirworthinessFromCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
