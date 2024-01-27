using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands
{
    public class UpdateDegitalArchieveDocTypeCommand : IRequest<Unit>
    {
        public DegitalArchieveDocTypeDto DegitalArchieveDocTypeDto { get; set; }
    }
}
