using Estudos.Domain.Validator;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Estudos.CrossCutting.IoC.Extensions;
public static class FluentValidationExtension
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
    {
        services.AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
            conf.AutomaticValidationEnabled = false;
            conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
        });

        services.AddFluentValidation(typeof(ClienteValidator));

        return services;
    }

    public static List<MessageResult>? GetErrors(this ValidationResult result)
    {
        return result.Errors?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
    }
}
