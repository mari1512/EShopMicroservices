
namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery():IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> products);

    internal class GetProductsHandler(IDocumentSession session,ILogger<GetProductsHandler> logger) 
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", request);

            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
