using FluentValidation;
using Microsoft.Extensions.Options;
using Xunarmand.Application.Common.Settings;
using Xunarmand.Domain.Entities;
using Xunarmand.Domain.Enums;

namespace Xunarmand.Infrastructure.Products.Validators;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation(IOptions<ValidationSettings> validation)
    {
        var validationSettingsValue = validation.Value;
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(product => product.ProductName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationSettingsValue.NameRegexPattern);

                RuleFor(product => product.Description)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(100);

                RuleFor(product => product.Price)
                    .NotEmpty()
                    .GreaterThan(0);
            });
        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(product => product.ProductName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationSettingsValue.NameRegexPattern);

                RuleFor(product => product.Description)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64);

                RuleFor(product => product.Price)
                    .NotEmpty()
                    .GreaterThan(0);

             
            }
        );
    }
};