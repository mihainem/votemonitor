﻿namespace Vote.Monitor.Api.Feature.ElectionRound.Get;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.CSOId)
            .NotEmpty();

        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
