/*
 * ChangeCase.cs
 *
 *   Created: 2022-11-26-06:57:54
 *   Modified: 2022-11-26-06:57:55
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

 #pragma warning disable
namespace JustinWritesCode.Functions.Strings;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime.MediaTypes;
using System.Threading.Tasks;
using Humanizer;
using JustinWritesCode.Payloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using static JustinWritesCode.Functions.Strings.Constants;
using static JustinWritesCode.Functions.Strings.Constants.Tags;
using static Microsoft.AspNetCore.Http.StatusCodes;

public class ChangeCase : ILog
{
	public ILogger Logger { get; }

	public ChangeCase(ILogger<ChangeCase> logger) => Logger = logger;

	[FunctionName(nameof(ChangeCase))]
	[OpenApiOperation(operationId: nameof(ChangeCase), tags: new[] { Strings, Mutation })]
	[OpenApiParameter(HttpRequestHeaderNames.Accept, In = ParameterLocation.Header, Required = false)]
	[OpenApiParameter(Headers.ChangeCase, In = ParameterLocation.Header, Required = false, Type = typeof(LetterCasing), Description = "The case to change the string to.")]
	[OpenApiParameter(Headers.Value, In = ParameterLocation.Header, Required = false, Type = typeof(string), Description = "The value whose case to change.")]
	[OpenApiRequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(AnyOfTypes.AnyOf<string, StringPayload>), Description = "The string to change the case of.", Required = false)]
	[Consumes(Application.Json, Text.Plain)]
	[Produces(Application.Json, Text.Plain)]
	public async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Anonymous, HttpRequestMethodNames.Post, Route = Routes.ChangeCase)] HttpRequest req)
	{
		var theString = req.GetContentType().Contains(TextMediaTypeNames.Plain, StringComparison.OrdinalIgnoreCase)
            ? await new StreamReader(req.Body).ReadToEndAsync()
            : (await req.ReadFromJsonAsync<StringPayload>()).Value;

		if (!req.Headers.TryGetValue("Accept", out var acceptHeader))
		{
			acceptHeader = ApplicationMediaTypeNames.Json;
		}

		var newCase = req.Headers.TryGetValue("X-Change-Case", out var changeCaseHeader) && Enum.TryParse<LetterCasing>(changeCaseHeader, out var casing) ? casing : LetterCasing.Title;
		theString = theString.ApplyCase(newCase);

		if(acceptHeader.ToString()?.Contains(Text.Plain, StringComparison.OrdinalIgnoreCase) ?? false)
        {
            return new ContentResult { Content = theString, ContentType = TextMediaTypeNames.Plain, StatusCode = (int)HttpStatusCode.OK };
        }
        else
        {
            return new OkObjectResult(new StringPayload { Value = theString });
        }
	}
}
