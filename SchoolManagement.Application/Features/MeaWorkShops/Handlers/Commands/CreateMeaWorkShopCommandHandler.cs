using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaWorkShop.Validators;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaWorkShops.Handlers.Commands
{
    public class CreateMeaWorkShopCommandHandler : IRequestHandler<CreateMeaWorkShopCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMeaWorkShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMeaWorkShopCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMeaWorkShopDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MeaWorkShopDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MeaWorkShop = _mapper.Map<MeaWorkShop>(request.MeaWorkShopDto);

                MeaWorkShop = await _unitOfWork.Repository<MeaWorkShop>().Add(MeaWorkShop);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MeaWorkShop.MeaWorkShopId;
            }

            return response;
        }
    }
}
