using Carter;
using Mapster;
using MediatR;
using Ordering.Application.DTOs;
using Ordering.Application.Orders.Queries.GetOrderByCustomer;

namespace Ordering.API.Endpoints
{
    //- Accepts a customer ID.
    //- Uses a GetOrdersByCustomerQuery to fetch orders.
    //- Returns the list of orders for that customer.

    //public record GetOrdersByCustomerRequest(Guid CustomerId);
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
    public class GetOrdersByCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{id}",async(Guid id,ISender sender) =>
            {
                var result = await sender.Send(new GetOrderByCustomerQuery(id));

                var response = result.Adapt<GetOrderByCustomerResult>();

                return Results.Ok(result);
            })
        .WithName("GetOrdersByCustomer")
        .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Customer")
        .WithDescription("Get Orders By Customer");
        }
    }
}
