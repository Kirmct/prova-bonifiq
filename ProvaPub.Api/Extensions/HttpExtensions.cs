using ProvaPub.Domain.Pagination;
using System.Text.Json;

namespace ProvaPub.Api.Extensions;

public static class HttpExtensions
{
    public static void AddPageHeader(this HttpResponse response, PageHeader header)
    {
        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
        response.Headers.Add("Access-Control-Expose-Header", "Pagination");
    }
}
