﻿namespace Vote.Monitor.Observer.Get;

public class Endpoint : Endpoint<Request, Results<Ok<ObserverModel>, NotFound>>
{
     readonly IReadRepository<Domain.Entities.ApplicationUserAggregate.Observer> _repository;

    public Endpoint(IReadRepository<Domain.Entities.ApplicationUserAggregate.Observer> repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/api/observers/{id:guid}");
    }

    public override async Task<Results<Ok<ObserverModel>, NotFound>> ExecuteAsync(Request req, CancellationToken ct)
    {
        var observer = await _repository.GetByIdAsync(req.Id, ct);
        if (observer is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new ObserverModel
        {
            Id = observer.Id,
            Login = observer.Login,
            Name = observer.Name,
            Status = observer.Status
        });
    }
}
