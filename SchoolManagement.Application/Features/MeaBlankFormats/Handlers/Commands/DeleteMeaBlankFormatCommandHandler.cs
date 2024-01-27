using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Handlers.Commands
{
    public class DeleteMeaBlankFormatCommandHandler : IRequestHandler<DeleteMeaBlankFormatCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMeaBlankFormatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMeaBlankFormatCommand request, CancellationToken cancellationToken)
        {
            var MeaBlankFormat = await _unitOfWork.Repository<MeaBlankFormat>().Get(request.MeaBlankFormatId);

            if (MeaBlankFormat == null)
                throw new NotFoundException(nameof(MeaBlankFormat), request.MeaBlankFormatId);

            await _unitOfWork.Repository<MeaBlankFormat>().Delete(MeaBlankFormat);
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
