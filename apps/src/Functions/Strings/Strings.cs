using System.Security.AccessControl;
namespace JustinWritesCode.Functions.Strings;

using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JustinWritesCode.Payloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using static System.Text.RegularExpressions.Regex;
using Errors =  JustinWritesCode.Payloads.ErrorResponses;
using Regex = System.Text.RegularExpressions.Regex;

public class RegexMatch
{
    [FunctionName(nameof(RegexMatch))]
    [OpenApiOperation(operationId: nameof(Run), tags: new[] { nameof(Regex) })]
	[OpenApiParameter(Headers.Regex, In = ParameterLocation.Header, Required = true, Description = "The regular expression to match against.")]
	[OpenApiParameter(Value, In = ParameterLocation.Header, Required = true, Description = "The string to match against the regular expression.")]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(string), Required = true, Description = "The string to echo")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The echoed string")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "regex/is-match")] HttpRequest req)
    {
        // this.logger.LogInformation("Echoing string");
		var value = req.Headers.ContainsKey(Value) ? req.Headers[Value].ToString() : null;
		if(value is null)
		{
			return new BadRequestObjectResult(Errors.ArgumentNullResponse(Headers.Value));
		}

        var payload = await req.ReadRequestBodyAsAsync<StringWithRegexPayload>().ConfigureAwait(false);
        return new OkObjectResult(new BooleanPayload(Regex.IsMatch(payload.Value, payload.Regex)));
    }

//     [FunctionName("IsUsername")]
//     [OpenApiOperation(operationId: "IsUsername", tags: new[] { "strings" })]
//     [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The echoed string")]
//     public IActionResult IsUsername(
//         [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "strings/{username}/is-username/")] HttpRequest req, string username)
//     {
//         this.logger.LogInformation("Testing if string is a username");
//         return new OkObjectResult(new BooleanPayload(Regex.IsMatch(username, "@[a-zA-Z0-9_]+")));
//     }
}

// public record StringPayload(string Value);
// public record StringWithSuccessPayload(string Value, bool Success);
// public record StringWithRegexPayload(string Value, string Regex) : StringPayload(Value);
