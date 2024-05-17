using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace WebAPI.ApiResponse;

public class SuccessHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; } = StatusCodes.Status200OK;

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();
}
