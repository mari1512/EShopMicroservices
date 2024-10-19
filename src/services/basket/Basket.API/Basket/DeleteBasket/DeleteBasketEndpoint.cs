
namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketRequest(string userName);
    public record DeleteBasketResponse(bool isSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{username}", async(string userName,ISender sender) =>
            {
                DeleteBasketResult result = await sender.Send(new DeleteBasketCommand(userName));
                DeleteBasketResponse response = new DeleteBasketResponse(result.isSuccess);
                return Results.Ok(response);
            }).WithName("DeleteProduct")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
        }
    }
}
