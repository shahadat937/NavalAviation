using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItems.Handlers.Commands
{
    public class DeleteLifeLimitItemCommandHandler : IRequestHandler<DeleteLifeLimitItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLifeLimitItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLifeLimitItemCommand request, CancellationToken cancellationToken)
        {
            var LifeLimitItem = await _unitOfWork.Repository<LifeLimitItem>().Get(request.LifeLimitItemId);

            if (LifeLimitItem == null)
                throw new NotFoundException(nameof(LifeLimitItem), request.LifeLimitItemId);

            await _unitOfWork.Repository<LifeLimitItem>().Delete(LifeLimitItem);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
