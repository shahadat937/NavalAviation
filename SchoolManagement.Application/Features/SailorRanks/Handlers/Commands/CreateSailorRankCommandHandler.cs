using AutoMapper;
using SchoolManagement.Application.DTOs.SailorRank.Validators;
using SchoolManagement.Application.Features.SailorRanks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.SailorRanks.Handlers.Commands
{
    public class CreateSailorRankCommandHandler : IRequestHandler<CreateSailorRankCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSailorRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSailorRankCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSailorRankDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SailorRankDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SailorRanks = _mapper.Map<SailorRank>(request.SailorRankDto);

                SailorRanks = await _unitOfWork.Repository<SailorRank>().Add(SailorRanks);
                try
                {
                  await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                  Console.WriteLine(ex);
                }
               

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SailorRanks.SailorRankId;
            }

            return response;
        }
    }
}
