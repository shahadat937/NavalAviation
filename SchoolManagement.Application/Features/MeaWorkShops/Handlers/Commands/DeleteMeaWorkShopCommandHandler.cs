using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaWorkShops.Handlers.Commands
{
    public class DeleteMeaWorkShopCommandHandler : IRequestHandler<DeleteMeaWorkShopCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMeaWorkShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMeaWorkShopCommand request, CancellationToken cancellationToken)
        {
            var MeaWorkShop = await _unitOfWork.Repository<MeaWorkShop>().Get(request.MeaWorkShopId);

            if (MeaWorkShop == null)
                throw new NotFoundException(nameof(MeaWorkShop), request.MeaWorkShopId);

            await _unitOfWork.Repository<MeaWorkShop>().Delete(MeaWorkShop);
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
