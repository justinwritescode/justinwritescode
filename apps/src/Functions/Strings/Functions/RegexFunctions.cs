using JustinWritesCode.Abstractions;
// using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Logging;

namespace JustinWritesCode.Functions.Strings;

public class RegexFunctions : ILog
{
    public ILogger Logger { get; }

    public RegexFunctions(ILogger<RegexFunctions> logger) => Logger = logger;

    [Function(nameof(Routes.RegexIsMatch))]
    [Op(nameof(Routes.RegexIsMatch), tags: new[] { Tags.Strings, Tags.Regex, Tags.Query })]
    [RequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(StringPayload), Description = "The string to check.", Required = false)]
    [RequestBody(contentType: TextMediaTypeNames.Plain, bodyType: typeof(string), Description = "The string to check.", Required = false)]
    [Param(Headers.Value, In = PLoc.Header, Required = false, Type = typeof(string), Description = "The string to check.")]
    [Param(Headers.Regex, In = PLoc.Header, Required = false, Type = typeof(string), Description = "The regular expression to check against")]
    public async Task<IActionResult> RegexIsMatch(
        [Http(AuthorizationLevel.Anonymous, HttpRequestMethodNames.Post, Route = Routes.RegexIsMatch)] HttpRequest req)
    {
        var theString = await req.ReadStringPayloadAsync();
        var regex = req.GetHeaderParam<string>(Headers.Regex);
        var result = REx.IsMatch(theString, regex);
        return req.HttpContext.FormatResponse<bool>(result);
    }
    [Function(nameof(Routes.RegexReplace))]
    [Op(nameof(Routes.RegexReplace), tags: new[] { Tags.Strings, Tags.Regex, Tags.Query })]
    [RequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(StringPayload), Description = "The string to check.", Required = false)]
    [RequestBody(contentType: TextMediaTypeNames.Plain, bodyType: typeof(string), Description = "The string to check.", Required = false)]
    [Param(Headers.Value, In = PLoc.Header, Required = false, Type = typeof(string), Description = "The string to check.")]
    [Param(Headers.Regex, In = PLoc.Header, Required = false, Type = typeof(string), Description = "The regular expression to check against")]
    [Param(Headers.Replacement, In = PLoc.Header, Required = false, Type = typeof(string), Description = "The replacement string")]
    public async Task<IActionResult> RegexReplace(
        [Http(AuthorizationLevel.Anonymous, HttpRequestMethodNames.Post, Route = Routes.RegexReplace)] HttpRequest req)
    {
        var theString = await req.ReadStringPayloadAsync();
        var regex = req.GetHeaderParam<string>(Headers.Regex);
        var replacement = req.GetHeaderParam<string>(Headers.Replacement);
        var result = REx.Replace(theString, regex, replacement);
        return req.HttpContext.FormatResponse<string>(result);
    }
}
