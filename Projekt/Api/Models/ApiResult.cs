namespace Api.Models;

public class ApiResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public string? Data { get; set; }
}
