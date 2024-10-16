
using Marten.Pagination;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery(int? pageNumber, int? pageSize) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> products);

    internal class GetProductsHandler(IDocumentSession session) 
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var products = await session.Query<Product>().ToPagedListAsync(request.pageNumber ?? 1,request.pageSize ?? 10,cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
