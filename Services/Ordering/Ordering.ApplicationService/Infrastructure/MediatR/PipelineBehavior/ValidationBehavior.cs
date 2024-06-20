using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ordering.ApplicationService.Infrastructure.MediatR.PipelineBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected IEnumerable<FluentValidation.IValidator<TRequest>> Validators { get; }

        public ValidationBehavior(IEnumerable<FluentValidation.IValidator<TRequest>> validators)
        {
            Validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (Validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                        .SelectMany(current => current.Errors)
                        .GroupBy(current => current.ErrorMessage)
                        .Select(current => current.Key)
                        .Where(current => current != null)
                        .ToList();

                var message = string.Join(" |#| ", failures);

                if (failures.Any())
                    throw new ValidationException(message);
            }

            return await next();
        }
    }
}