﻿using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Vote.Monitor.Core.Helpers;

namespace Vote.Monitor.Feature.PollingStation.Specifications;

public class ListPollingStationsSpecification : Specification<Domain.Entities.PollingStationAggregate.PollingStation>
{
    public ListPollingStationsSpecification(string? addressFilter, Dictionary<string, string>? tagFilters, int pageSize, int page)
    {
        Query
            .Search(x => x.Address, addressFilter, !string.IsNullOrWhiteSpace(addressFilter))
            .Where(station => EF.Functions.JsonContains(station.Tags, tagFilters), tagFilters is not null && tagFilters.Count != 0)
            .OrderBy(x => x.DisplayOrder)
            .Skip(PaginationHelper.CalculateSkip(pageSize, page))
            .Take(PaginationHelper.CalculateTake(pageSize));
    }
}
