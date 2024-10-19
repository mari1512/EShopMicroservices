
namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart cart);
    public record StoreBasketResponse(string userName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket",async(StoreBasketRequest request,ISender sender) =>
            {
                var command = new StoreBasketCommand(request.cart);
                StoreBasketResult result = await sender.Send(command);

                var response = new StoreBasketResponse(result.userName);
                return Results.Ok(response);
            })
        .WithName("CreateProduct")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
        }
    }
}
