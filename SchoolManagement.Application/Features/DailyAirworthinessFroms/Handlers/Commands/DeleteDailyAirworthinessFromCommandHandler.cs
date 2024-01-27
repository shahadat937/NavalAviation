using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Commands
{
    public class DeleteDailyAirworthinessFromCommandHandler : IRequestHandler<DeleteDailyAirworthinessFromCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDailyAirworthinessFromCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDailyAirworthinessFromCommand request, CancellationToken cancellationToken)
        {
            var DailyAirworthinessFrom = await _unitOfWork.Repository<DailyAirworthinessFrom>().Get(request.DailyAirworthinessFromId);

            if (DailyAirworthinessFrom == null)
                throw new NotFoundException(nameof(DailyAirworthinessFrom), request.DailyAirworthinessFromId);

            await _unitOfWork.Repository<DailyAirworthinessFrom>().Delete(DailyAirworthinessFrom);
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
