using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SparesCategory.Validators;
using SchoolManagement.Application.Features.SparesCategories.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Commands
{
    public class CreateSparesCategoryCommandHandler : IRequestHandler<CreateSparesCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSparesCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSparesCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSparesCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SparesCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SparesCategory = _mapper.Map<SparesCategory>(request.SparesCategoryDto);

                SparesCategory = await _unitOfWork.Repository<SparesCategory>().Add(SparesCategory);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SparesCategory.SparesCategoryId;
            }

            return response;
        }
    }
}
