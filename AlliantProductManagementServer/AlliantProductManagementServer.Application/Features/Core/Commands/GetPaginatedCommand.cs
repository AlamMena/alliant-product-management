using AlliantProductManagementServer.Domain.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Core.Commands
{
    public class GetPaginatedCommand<T> : IRequest<PaginatedResponse<T>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
