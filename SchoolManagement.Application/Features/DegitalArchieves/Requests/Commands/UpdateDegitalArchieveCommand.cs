using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands
{
    public class UpdateDegitalArchieveCommand : IRequest<Unit>
    {
        public CreateDegitalArchieveDto UpdateDegitalArchieveDto { get; set; }
    }
}
