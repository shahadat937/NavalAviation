using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Statuses.Requests.Commands
{
    public class DeleteStatusCommand : IRequest
    {
        public int StatusId { get; set; }
    }
} 
