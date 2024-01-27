using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.AcctStores;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AcctStores.Requests.Queries
{
   public class GetAcctStoreListRequest : IRequest<PagedResult<AcctStoreDto>>
    {
        public QueryParams QueryParams { get; set; }
    } 
}
