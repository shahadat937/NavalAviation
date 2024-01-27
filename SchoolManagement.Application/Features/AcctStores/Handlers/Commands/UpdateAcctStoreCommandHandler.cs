using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AcctStores.Validators;
using SchoolManagement.Application.Features.AcctStores.Requests.Commands;

namespace SchoolManagement.Application.Features.AcctStores.Handlers.Commands
{
    public class UpdateAcctStoreCommandHandler : IRequestHandler<UpdateAcctStoreCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAcctStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAcctStoreCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAcctStoreDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AcctStoreDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AcctStore = await _unitOfWork.Repository<AcctStore>().Get(request.AcctStoreDto.AcctStoreId);

            if (AcctStore is null)
                throw new NotFoundException(nameof(AcctStore), request.AcctStoreDto.AcctStoreId);

            _mapper.Map(request.AcctStoreDto, AcctStore);

            await _unitOfWork.Repository<AcctStore>().Update(AcctStore);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
