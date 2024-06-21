using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using WeatherApp.Database;
using WeatherApp.Entities;
using Environment = System.Environment;

namespace WeatherApp.Features.History;

public static class CreateHistoryRecord
{
    public class CreateHistoryRecordRequest : IRequest<Result>
    {
        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }

    public class Validator : AbstractValidator<CreateHistoryRecordRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TemperatureC).NotEmpty();
            RuleFor(x => x.Summary).NotEmpty();
        }
    }

    internal sealed class Handler(AppDbContext dbContext, IValidator<CreateHistoryRecordRequest> validator) : IRequestHandler<CreateHistoryRecordRequest, Result>
    {
        public async Task<Result> Handle(CreateHistoryRecordRequest request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Result.Failure(string.Join(Environment.NewLine, validationResult.Errors));
            }

            var record = new WeatherHistoryRecord
            {
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                TemperatureC = request.TemperatureC,
                Summary = request.Summary
            };
            dbContext.Add(record);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}