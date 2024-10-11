using FluentValidation;
using Microsoft.Extensions.Options;
using Xunarmand.Application.Common.Settings;
using Xunarmand.Domain.Entities;
using Xunarmand.Domain.Enums;

namespace Xunarmand.Infrastructure.Users.Validators;

public class UserValidation:AbstractValidator<User>
{
    public UserValidation(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;
        
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
              
                RuleFor(client => client.Name)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationSettingsValue.NameRegexPattern);
                    

                RuleFor(client => client.EmailAddress)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(128)
                    .Matches(validationSettingsValue.EmailRegexPattern);

                RuleFor(client => client.PasswordHash).NotEmpty();
            }
        );
        
        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
              

                RuleFor(client => client.Name)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationSettingsValue.NameRegexPattern);
                    

                RuleFor(client => client.EmailAddress)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(128)
                    .Matches(validationSettingsValue.EmailRegexPattern);

                RuleFor(client => client.PasswordHash).NotEmpty();
            }
        );
        
        
    }
    
}