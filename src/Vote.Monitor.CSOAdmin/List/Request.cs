﻿namespace Vote.Monitor.CSOAdmin.List;

public class Request
{
    [QueryParam]
    public string? NameFilter { get; set; }

    [QueryParam]
    [JsonConverter(typeof(SmartEnumNameConverter<UserStatus, int>))]
    public UserStatus? Status { get; set; }

    [QueryParam]
    [DefaultValue(1)]
    public int PageNumber { get; set; } = 1;

    [QueryParam]
    [DefaultValue(100)]
    public int PageSize { get; set; } = 100;
}
