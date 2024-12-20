﻿using Carter;
using Mapster;
using MediatR;
using Ordering.Application.DTOs;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints
{
    //- Accepts a name parameter.
    //- Constructs a GetOrdersByNameQuery.
    //- Retrieves and returns matching orders.

    //public record GetOrdersByNameRequest(string Name);
    public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
    public class GetOrdersByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}",async(string orderName,ISender sender) =>
            {
                var result = await sender.Send(new GetOrderByNameQuery(orderName));

                var response = result.Adapt<GetOrdersByNameResponse>();
                return Results.Ok(result);
            })
        .WithName("GetOrdersByName")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Name")
        .WithDescription("Get Orders By Name");
        }
    }
}
