using System.Net;

namespace App.Domain.Entities.Application;

public class RequestViolationException : Exception
{
    private readonly HttpStatusCode _code;
    public int Code
    {
        get => ((int)_code);
    }
    public RequestViolationException (HttpStatusCode code, string? mesage = null) : base(mesage)
    {
        _code = code;
    }
}
