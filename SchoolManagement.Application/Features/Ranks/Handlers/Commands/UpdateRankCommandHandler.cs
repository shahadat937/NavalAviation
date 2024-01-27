using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Rank.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Ranks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Ranks.Handlers.Commands
{
    public class UpdateRankCommandHandler : IRequestHandler<UpdateRankCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRankCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRankDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.RankDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Rank = await _unitOfWork.Repository<Rank>().Get(request.RankDto.RankId);

            if (Rank is null)
                throw new NotFoundException(nameof(Rank), request.RankDto.RankId);

            _mapper.Map(request.RankDto, Rank);

            await _unitOfWork.Repository<Rank>().Update(Rank);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
