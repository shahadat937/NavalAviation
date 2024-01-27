using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ConditionOfItems.Handlers.Commands
{
    public class DeleteConditionOfItemCommandHandler : IRequestHandler<DeleteConditionOfItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteConditionOfItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteConditionOfItemCommand request, CancellationToken cancellationToken)
        {
            var ConditionOfItem = await _unitOfWork.Repository<ConditionOfItem>().Get(request.ConditionOfItemId);

            if (ConditionOfItem == null)
                throw new NotFoundException(nameof(ConditionOfItem), request.ConditionOfItemId);

            await _unitOfWork.Repository<ConditionOfItem>().Delete(ConditionOfItem);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
