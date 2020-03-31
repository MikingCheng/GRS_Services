using FluentValidation;
using Microsoft.Extensions.Logging;
using WWGRS.Service.Ordering.API.Applicaiton.Commands;

namespace WWGRS.Service.Ordering.API.Applicaiton.Validations
{
    public class IdentifiedCommandValidator : AbstractValidator<IdentifiedCommand<CreateOrderCommand, bool>>
    {
        public IdentifiedCommandValidator(ILogger<IdentifiedCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotEmpty();

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
