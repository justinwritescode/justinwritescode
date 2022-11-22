using System.Net.Mime;
/*
 * IsEven.cs
 *
 *   Created: 2022-11-19-11:38:37
 *   Modified: 2022-11-19-11:38:37
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace JustinWritesCode.Functions.Numbers;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Logging;
// using JustinWritesCode.Http.Extensions;
using static Microsoft.OpenApi.Models.ParameterLocation;
using PLoc = Microsoft.OpenApi.Models.ParameterLocation;

public class IsEven
{
	private readonly ILogger<IsEven> _logger;

	public IsEven(ILogger<IsEven> log)
	{
		_logger = log;
	}

	[Function(nameof(IsEven))]
	[Op(operationId: nameof(IsEven), tags: new[] { Tags.Logic })]
	[Param(name: HeaderNames.ContentType, In = PLoc.Header, Required = true, Type = typeof(string), Summary = "The content type of the request body.", Description = "The content type of the request body.")]
	[Response(statusCode: OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
	public async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, string Accept = Text.Plain)
	{
		_logger.LogInformation("C# HTTP trigger function processed a request.");

		var number =
			req.ContentType switch
			{
				Application.Json => (await req.ReadFromJsonAsync<NumericPayload>().ConfigureAwait(false)).Value,
				Text.Plain => decimal.Parse(await new StreamReader(req.Body).ReadToEndAsync()),
				_ => 0
			};

		var responseMessage = number % 2 == 0 ? "Even" : "Odd";

		return new OkObjectResult(new { Value = (number % 2 == 0) });
	}

	public struct NumericPayload { public decimal Value; }
}
