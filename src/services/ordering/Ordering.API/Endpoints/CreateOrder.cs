using Carter;
using Mapster;
using MediatR;
using Ordering.Application.DTOs;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints
{
    //- Accepts a CreateOrderRequest object.
    //- Maps the request to a CreateOrderCommand.
    //- Uses MediatR to send the command to the corresponding handler.
    //- Returns a response with the created order's ID.

    public record CreateOrderRequest(OrderDto order);
    public record CreateOrderResponse(Guid Id);

    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders",async(CreateOrderCommand request,ISender sender) =>
            {
                //CreateOrderCommand command = request;

                var result = await sender.Send(request);

                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/orders/{response.Id}", response);
            })
        .WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Order")
        .WithDescription("Create Order");
        }
    }
}
