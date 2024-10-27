using Basket.API.DTOs;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketChekoutDto BasketCheckoutDto)
    : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);
    public class CheckoutCommandHandler
    {
    }
}
