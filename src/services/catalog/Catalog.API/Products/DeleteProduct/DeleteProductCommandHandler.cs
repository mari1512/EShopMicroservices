using Catalog.API.Exceptions;
using FluentValidation;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool isSucess);

    //public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    //{
    //    public DeleteProductCommandValidator()
    //    {
    //        RuleFor(x => x.id).NotEmpty().WithMessage("Product Id is required");
    //    }
    //}
    internal class DeleteProductCommandHandler(IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            session.Delete<Product>(request.id);

            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
