using AutoMapper;
using SchoolManagement.Application.DTOs.SailorRank.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SailorRanks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Handlers.Commands
{
    public class UpdateSailorRankCommandHandler : IRequestHandler<UpdateSailorRankCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSailorRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSailorRankCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSailorRankDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SailorRankDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SailorRanks = await _unitOfWork.Repository<SailorRank>().Get(request.SailorRankDto.SailorRankId);

            if (SailorRanks is null)
                throw new NotFoundException(nameof(SailorRank), request.SailorRankDto.SailorRankId);

            _mapper.Map(request.SailorRankDto, SailorRanks);

            await _unitOfWork.Repository<SailorRank>().Update(SailorRanks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
