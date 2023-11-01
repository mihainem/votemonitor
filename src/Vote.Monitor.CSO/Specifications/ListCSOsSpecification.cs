﻿using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Vote.Monitor.Core.Helpers;
using Vote.Monitor.Domain.Entities.CSOAggregate;

namespace Vote.Monitor.CSO.Specifications;

public class ListCSOsSpecification : Specification<Domain.Entities.CSOAggregate.CSO>
{
    public ListCSOsSpecification(string? nameFilter, CSOStatus? csoStatus, int pageSize, int page)
    {
        if (!string.IsNullOrEmpty(nameFilter))
        {
            Query
                .Where(x => EF.Functions.Like(x.Name, $"%{nameFilter}%"));
        }

        if (csoStatus != null)
        {
            Query
                .Where(x => x.Status == csoStatus);
        }

        Query
            .Skip(PaginationHelper.CalculateSkip(pageSize, page))
            .Take(PaginationHelper.CalculateTake(pageSize));
    }
}
