using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SparesCategories.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Commands
{
    public class DeleteSparesCategoryCommandHandler : IRequestHandler<DeleteSparesCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSparesCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSparesCategoryCommand request, CancellationToken cancellationToken)
        {
            var SparesCategory = await _unitOfWork.Repository<SparesCategory>().Get(request.SparesCategoryId);

            if (SparesCategory == null)
                throw new NotFoundException(nameof(SparesCategory), request.SparesCategoryId);

            await _unitOfWork.Repository<SparesCategory>().Delete(SparesCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
