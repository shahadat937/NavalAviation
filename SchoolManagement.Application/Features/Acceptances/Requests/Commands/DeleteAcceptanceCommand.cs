using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Commands
{
    public class DeleteAcceptanceCommand : IRequest
    {
        public int AcceptanceId { get; set; }
    }
} 
