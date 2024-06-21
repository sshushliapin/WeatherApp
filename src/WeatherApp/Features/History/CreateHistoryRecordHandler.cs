using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using WeatherApp.Database;
using WeatherApp.Entities;

namespace WeatherApp.Features.History;

public record CreateHistoryRecordRequest(int TemperatureC, string? Summary) : IRequest<Result>;

public class CreateHistoryRecordValidator : AbstractValidator<CreateHistoryRecordRequest>
{
    public CreateHistoryRecordValidator()
    {
        RuleFor(x => x.TemperatureC).NotEmpty();
        RuleFor(x => x.Summary).NotEmpty();
    }
}

public class CreateHistoryRecordHandler(AppDbContext dbContext, IValidator<CreateHistoryRecordRequest> validator)
    : IRequestHandler<CreateHistoryRecordRequest, Result>
{
    public async Task<Result> Handle(CreateHistoryRecordRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
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