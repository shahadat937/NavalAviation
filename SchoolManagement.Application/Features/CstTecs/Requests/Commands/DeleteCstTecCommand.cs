using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CstTecs.Requests.Commands
{
    public class DeleteCstTecCommand : IRequest
    {
        public int CstTecId { get; set; }
    }
} 
