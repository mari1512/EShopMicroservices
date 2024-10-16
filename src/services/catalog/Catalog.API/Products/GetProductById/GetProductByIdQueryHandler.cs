
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id):IQuery<GetProdctByIdResult>;
    public record GetProdctByIdResult(Product product);
    public class GetProductByIdQueryHandler (IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetProdctByIdResult>
    {
        public async Task<GetProdctByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(query.id);
            }
            return new GetProdctByIdResult(product);
        }
    }
}
