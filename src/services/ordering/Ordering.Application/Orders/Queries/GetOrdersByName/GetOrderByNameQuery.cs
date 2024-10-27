using BuildingBlocks.CQRS;
using Ordering.Application.DTOs;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public record GetOrderByNameQuery(string name):
        IQuery<GetOrderByNameResult>;

    public record GetOrderByNameResult(IEnumerable<OrderDto> orders);
}
