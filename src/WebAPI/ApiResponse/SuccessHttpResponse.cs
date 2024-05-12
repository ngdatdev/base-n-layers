using System;
using System.Text.Json.Serialization;

namespace WebAPI.ApiResponse;

public class SuccessHttpResponse
{
    [JsonIgnore]
    public int HttpCode { get; init; } = 400;

    public DateTime ResponseTime { get; init; } =
        TimeZoneInfo.ConvertTimeFromUtc(
            dateTime: DateTime.UtcNow,
            destinationTimeZone: TimeZoneInfo.FindSystemTimeZoneById(id: "SE Asia Standard Time")
        );

    public object Body { get; init; } = new();
}
