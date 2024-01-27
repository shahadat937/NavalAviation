using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetItemNameIsExistCheckRequest : IRequest<bool>
    {
        public string NameOfItem { get; set; }
    }
}
