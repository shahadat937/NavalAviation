using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Handlers.Commands
{
    public class DeleteSourceOfSupplyCommandHandler : IRequestHandler<DeleteSourceOfSupplyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSourceOfSupplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSourceOfSupplyCommand request, CancellationToken cancellationToken)
        {
            var SourceOfSupply = await _unitOfWork.Repository<SourceOfSupply>().Get(request.SourceOfSupplyId);

            if (SourceOfSupply == null)
                throw new NotFoundException(nameof(SourceOfSupply), request.SourceOfSupplyId);

            await _unitOfWork.Repository<SourceOfSupply>().Delete(SourceOfSupply);
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
