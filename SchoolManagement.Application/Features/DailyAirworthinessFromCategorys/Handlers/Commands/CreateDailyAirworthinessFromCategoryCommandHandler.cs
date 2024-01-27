using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory.Validators;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Commands
{
    public class CreateDailyAirworthinessFromCategoryCommandHandler : IRequestHandler<CreateDailyAirworthinessFromCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDailyAirworthinessFromCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDailyAirworthinessFromCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDailyAirworthinessFromCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DailyAirworthinessFromCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DailyAirworthinessFromCategory = _mapper.Map<DailyAirworthinessFromCategory>(request.DailyAirworthinessFromCategoryDto);

                DailyAirworthinessFromCategory = await _unitOfWork.Repository<DailyAirworthinessFromCategory>().Add(DailyAirworthinessFromCategory);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DailyAirworthinessFromCategory.DailyAirworthinessFromCategoryId;
            }

            return response;
        }
    }
}
