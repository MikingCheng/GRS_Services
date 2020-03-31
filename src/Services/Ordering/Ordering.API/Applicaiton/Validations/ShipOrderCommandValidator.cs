﻿using FluentValidation;
using Microsoft.Extensions.Logging;
using WWGRS.Service.Ordering.API.Applicaiton.Commands;

namespace WWGRS.Service.Ordering.API.Applicaiton.Validations
{
    public class ShipOrderCommandValidator : AbstractValidator<ShipOrderCommand>
    {
        public ShipOrderCommandValidator(ILogger<ShipOrderCommandValidator> logger)
        {
            RuleFor(order => order.OrderNumber).NotEmpty().WithMessage("No orderId found");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
