using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Commands
{
    public class DeleteDailyAirworthinessFromCategoryCommandHandler : IRequestHandler<DeleteDailyAirworthinessFromCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDailyAirworthinessFromCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDailyAirworthinessFromCategoryCommand request, CancellationToken cancellationToken)
        {
            var DailyAirworthinessFromCategory = await _unitOfWork.Repository<DailyAirworthinessFromCategory>().Get(request.DailyAirworthinessFromCategoryId);

            if (DailyAirworthinessFromCategory == null)
                throw new NotFoundException(nameof(DailyAirworthinessFromCategory), request.DailyAirworthinessFromCategoryId);

            await _unitOfWork.Repository<DailyAirworthinessFromCategory>().Delete(DailyAirworthinessFromCategory);
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
