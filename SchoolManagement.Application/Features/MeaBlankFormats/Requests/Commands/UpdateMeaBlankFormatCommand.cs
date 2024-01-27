using MediatR;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands
{
    public class UpdateMeaBlankFormatCommand : IRequest<Unit>
    {
        public CreateMeaBlankFormatDto UpdateMeaBlankFormatDto { get; set; }
    }
}
