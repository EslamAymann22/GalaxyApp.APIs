using FluentValidation;
using MediatR;

namespace GalaxyApp.Core
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle
            (TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any()) // UnHappy Case 
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var messages = failures.Select(x => x.PropertyName + ": " + x.ErrorMessage).ToList();
                    string message = "";
                    foreach (var MSG in messages)
                    {
                        message += MSG + "\n";
                    }
                    throw new ValidationException(message);
                }
            }
            return await next();
        }
    }
}
