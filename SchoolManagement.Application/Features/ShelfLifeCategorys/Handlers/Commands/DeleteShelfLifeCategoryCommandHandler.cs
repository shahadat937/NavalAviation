using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Handlers.Commands
{
    public class DeleteShelfLifeCategoryCommandHandler : IRequestHandler<DeleteShelfLifeCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteShelfLifeCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteShelfLifeCategoryCommand request, CancellationToken cancellationToken)
        {
            var ShelfLifeCategory = await _unitOfWork.Repository<ShelfLifeCategory>().Get(request.ShelfLifeCategoryId);

            if (ShelfLifeCategory == null)
                throw new NotFoundException(nameof(ShelfLifeCategory), request.ShelfLifeCategoryId);

            await _unitOfWork.Repository<ShelfLifeCategory>().Delete(ShelfLifeCategory);
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
