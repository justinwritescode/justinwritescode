/*
 * Echo.cs
 *
 *   Created: 2022-11-26-04:00:36
 *   Modified: 2022-11-26-04:00:37
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using AnyOfTypes;
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

namespace JustinWritesCode.Functions.Strings
{
    public class Echo
    {
        // private readonly ILogger<Echo> _logger;

        // public Echo(ILogger<Echo> log)
        // {
        //     _logger = log;
        // }

		[FunctionName(nameof(Echo))]
		[OpenApiOperation(operationId: nameof(Echo), tags: new[] { Tags.Strings })]
		[OpenApiParameter(HttpRequestHeaderNames.Accept, In = ParameterLocation.Header, Required = false)]
		[OpenApiParameter(Value, In = ParameterLocation.Header, Required = false, Description = "The string to echo back.")]
		[OpenApiRequestBody(Application.Json, bodyType: typeof(AnyOfTypes.AnyOf<string, StringPayload>), Description = "The string to echo.", Required = false)]
		[Consumes(Application.Json, Text.Plain)]
		[Produces(Application.Json, Text.Plain)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, HttpRequestMethodNames.Post, Route = Routes.Echo)] HttpRequest req)
        {
            // _logger.LogInformation("C# HTTP trigger function processed a request.");
			var theString = req.Headers.ContainsKey(Value) ?
				req.Headers[Value].ToString() :
				req.ContentType switch
				{
					Text.Plain => await new StreamReader(req.Body).ReadToEndAsync(),
					Application.Json => (await req.ReadFromJsonAsync<StringPayload>()).Value,
					_ => (await req.ReadFromJsonAsync<StringPayload>()).Value
				};

			if(!req.Headers.TryGetValue("Accept", out var acceptHeader))
			{
				acceptHeader = Application.Json;
			}

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
}
