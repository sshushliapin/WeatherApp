using System.ComponentModel;
using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using WeatherApp.Domain.Forecast;
using WeatherApp.Domain.History;

namespace WeatherApp.History;

public record CreateHistoryRecordRequest : IRequest<Result>
{
    [DefaultValue("2024-06-22")]
    public DateTime Date { get; init; }

    [DefaultValue(25)]
    public int TemperatureC { get; init; }

    [DefaultValue("Warm")]
    public string? Summary { get; init; }
}

public class CreateHistoryRecordValidator : AbstractValidator<CreateHistoryRecordRequest>
{
    public CreateHistoryRecordValidator()
    {
        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.Now);
        RuleFor(x => x.TemperatureC).InclusiveBetween(Temperature.MinC, Temperature.MaxC);
        RuleFor(x => x.Summary).NotEmpty();
    }
}

public class CreateHistoryRecordHandler(IHistoryRepository repository, IValidator<CreateHistoryRecordRequest> validator)
    : IRequestHandler<CreateHistoryRecordRequest, Result>
{
    public async Task<Result> Handle(CreateHistoryRecordRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Failure(string.Join(Environment.NewLine, validationResult.Errors));
        }

        var record = new HistoryRecord(DateOnly.FromDateTime(request.Date), request.TemperatureC, request.Summary);
        await repository.AddHistoryRecord(record, cancellationToken);

        return Result.Success();
    }
}