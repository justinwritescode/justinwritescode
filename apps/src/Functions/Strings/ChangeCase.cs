/*
 * ChangeCase.cs
 *
 *   Created: 2022-11-26-06:57:54
 *   Modified: 2022-11-26-06:57:55
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace JustinWritesCode.Functions.Strings;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AnyOfTypes;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net.Http;
using JustinWritesCode.Payloads;
using static JustinWritesCode.Functions.Strings.Constants;
using static JustinWritesCode.Functions.Strings.Constants.Tags;
using static System.Net.Http.Headers.HttpRequestHeaderNames;

public class ChangeCase
{
	[FunctionName(nameof(ChangeCase))]
	[OpenApiOperation(operationId: "Run", tags: new[] { Strings, Mutation })]
	[OpenApiParameter("Accept", In = ParameterLocation.Header, Required = false)]
	[OpenApiParameter("X-Change-Case", In = ParameterLocation.Header, Required = false, Type = typeof(LetterCasing), Description = "The case to change the string to.")]
	[OpenApiRequestBody(Application.Json, typeof(AnyOf<string, StringPayload>), Description = "The string to change the case of.", Required = true)]
	[Consumes(typeof(AnyOf<string, StringPayload>), Application.Json, Text.Plain)]
	[Produces(Application.Json, Text.Plain)]
	public async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Anonymous, HttpRequestMethodNames.Post, Route = Routes.ChangeCase)] HttpRequest req)
	{
		var theString = req.GetContentType() switch
		{
			Application.Json => (await req.ReadFromJsonAsync<StringPayload>()).Value,
			Text.Plain => await new StreamReader(req.Body).ReadToEndAsync(),
			_ => null
		};

		if (!req.Headers.TryGetValue("Accept", out var acceptHeader))
		{
			acceptHeader = Application.Json;
		}

		var newCase = req.Headers.TryGetValue("X-Change-Case", out var changeCaseHeader) && Enum.TryParse<LetterCasing>(changeCaseHeader, out var casing) ? casing : LetterCasing.Title;
		theString = theString.ApplyCase(newCase);

		return (string)acceptHeader switch
		{
			Application.Json => new OkObjectResult(new StringPayload(theString)),
			Text.Plain => new ContentResult
			{
				Content = theString,
				ContentType = Text.Plain,
				StatusCode = (int)HttpStatusCode.OK
			},
			_ => new BadRequestObjectResult(new { error = "Invalid Accept header" }),
		};
	}
}
