using System.Net.Mime;
using System.Security.AccessControl;
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
using System.Net.Http.Headers;
using JustinWritesCode.Payloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using static System.Net.HttpStatusCode;
using static System.Net.Mime.MediaTypeNames;
// using static Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiParameterLocation;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Microsoft.Azure.WebJobs.Extensions.Http.AuthorizationLevel;
using static Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiAuthLevelType;
using static Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType;
using static Microsoft.OpenApi.Models.ParameterLocation;
using AuthLvl = Microsoft.Azure.WebJobs.Extensions.Http.AuthorizationLevel;
using PLoc = Microsoft.OpenApi.Models.ParameterLocation;
using SLoc = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType;

public class IsEven
{
	private readonly ILogger _logger;

	public IsEven(ILogger<IsEven> logger)
	{
		_logger = logger;
	}

	[Function(nameof(IsEvenPost))]
	[Op(operationId: nameof(IsEvenPost), tags: new[] { Logic })]
	// [Param(name: HttpRequestHeaderNames.ContentType, In = Header, Required = true, Type = typeof(string), Summary = "The content type of the request body.", Description = "The content type of the request body.")]
	// [Param(name: HttpRequestHeaderNames.Accept, In = Header, Required = true, Type = typeof(string), Summary = "The requested content type of the response body.", Description = "The requested content type of the response body.")]
	[Request(Application.Json, typeof(NumericPayload))]
	[Request(Text.Plain, typeof(decimal))]
	// [Response(OK, Text.Plain, typeof(string), Description = "The OK response")]
	// [Response(OK, Application.Json, typeof(BooleanPayload), Description = "The OK response")]
	[ProducesResponseType(typeof(BooleanPayload), Status200OK)]
	[ProducesResponseType(typeof(string), Status200OK)]
	public async Task<IActionResult> IsEvenPost([Http(AuthLvl.Anonymous, Post, Route = "is-even")] HttpRequest req)
	{
		var number =
			req.ContentType switch
			{
				Application.Json => global::System.Text.Json.JsonSerializer.Deserialize<NumericPayload>(await req.ReadAsStringAsync()).Value,
				Text.Plain => decimal.Parse(await new StreamReader(req.Body).ReadToEndAsync()),
				_ => 0
			};

		_logger.LogInformation($"C# HTTP trigger function processed a request: {nameof(IsEven)}({number})");


		var responseMessage = number % 2 == 0 ? "Even" : "Odd";

		return await Task.FromResult(new OkObjectResult(new { Value = (number % 2 == 0), Message = responseMessage }));
	}

	[FunctionName(nameof(IsEvenGet))]
	[OpenApiOperation(operationId: nameof(IsEvenGet), tags: new[] { Tags.Logic })]
	[OpenApiParameter(name: "value", In = PLoc.Query, Required = true, Type = typeof(decimal), Summary = "The number to test.", Description = "The number to test.")]
	[OpenApiResponseWithBody(statusCode: OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
	public async Task<IActionResult> IsEvenGet(
		[Http(AuthLvl.Anonymous, Get, Route = "is-even/{number}")] HttpRequest req, decimal number)
	{
		_logger.LogInformation("C# HTTP trigger function processed a request.");

		var responseMessage = number % 2 == 0 ? "Even" : "Odd";

		return await Task.FromResult(new OkObjectResult(new { Value = (number % 2 == 0), Message = responseMessage }));
	}
}
