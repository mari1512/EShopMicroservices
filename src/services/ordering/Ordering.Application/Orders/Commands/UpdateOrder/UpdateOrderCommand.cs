using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto order)
        :ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.order.OrderName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.order.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(x => x.order.OrderItems).NotEmpty().WithMessage("OrderItems is required");
        }
    }
}
