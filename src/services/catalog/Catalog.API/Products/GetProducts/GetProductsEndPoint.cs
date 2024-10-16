
using Catalog.API.Products.CreateProduct;
using Mapster;

namespace Catalog.API.Products.GetProducts
{
     public record GetProductRequest(int? pageNumber,int? pageSize);
    public record GetProductsResponse(IEnumerable<Product> products);

    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
            {
                var query = new GetProductsQuery(request.pageNumber, request.pageSize);

                var result = await sender.Send(query);

                GetProductsResponse response = result.Adapt<GetProductsResponse>();

                return Results.Ok(result);

            })
            .WithName("GetProducts")
            //.Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}
