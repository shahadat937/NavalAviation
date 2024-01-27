using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Store.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Stores.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Stores.Handlers.Commands
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStoreDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.StoreDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Store = await _unitOfWork.Repository<Store>().Get(request.StoreDto.StoreId);

            if (Store is null)
                throw new NotFoundException(nameof(Store), request.StoreDto.StoreId);

            _mapper.Map(request.StoreDto, Store);

            await _unitOfWork.Repository<Store>().Update(Store);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
