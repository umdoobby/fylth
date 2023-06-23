using System.Net;

namespace Fylth.Models;

public class GetLoginResponse
{
    public bool WasSuccessful { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public string Response { get; set; }
}