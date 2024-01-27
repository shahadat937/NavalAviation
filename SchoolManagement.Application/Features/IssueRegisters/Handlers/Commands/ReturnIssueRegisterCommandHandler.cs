using System;
using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.IssueRegister.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using Microsoft.VisualBasic;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Commands
{
    public class ReturnIssueRegisterCommandHandler : IRequestHandler<ReturnIssueRegisterCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     
        public ReturnIssueRegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ReturnIssueRegisterCommand request, CancellationToken cancellationToken)
        {
            var IssueRegister = await _unitOfWork.Repository<IssueRegister>().Get(request.ReturnIssueRegisterDto.IssueRegisterId);

            if (IssueRegister is null)
                throw new NotFoundException(nameof(IssueRegister), request.ReturnIssueRegisterDto.IssueRegisterId);

            IssueRegister.ReturnQty = IssueRegister.ReturnQty - request.ReturnIssueRegisterDto.ReturningQty;

            var ItemStor = await _unitOfWork.Repository<ItemStor>().Get(request.ReturnIssueRegisterDto.ItemStoreId);

            if (ItemStor is null)
              throw new NotFoundException(nameof(ItemStor), request.ReturnIssueRegisterDto.ItemStoreId);

            ItemStor.IssuedQty = ItemStor.IssuedQty - request.ReturnIssueRegisterDto.ReturningQty;
            ItemStor.TYQty = ItemStor.TYQty - request.ReturnIssueRegisterDto.ReturningQty;
            ItemStor.AvailableQty = ItemStor.AvailableQty + request.ReturnIssueRegisterDto.ReturningQty;


            await _unitOfWork.Repository<ItemStor>().Update(ItemStor);
            await _unitOfWork.Repository<IssueRegister>().Update(IssueRegister);
            await _unitOfWork.Save();


            return Unit.Value;
        }
    }
}
