/*
 * Echo.cs
 *
 *   Created: 2022-11-26-04:00:36
 *   Modified: 2022-11-26-04:00:37
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
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

		[FunctionName("Echo")]
		[OpenApiOperation(operationId: "Run", tags: new[] { Tags.Strings })]
		[OpenApiParameter(HttpRequestHeaderNames.Accept, In = ParameterLocation.Header, Required = false)]
		[OpenApiParameter(Value, In = ParameterLocation.Header, Required = false, Description = "The string to echo back.")]
		[OpenApiRequestBody(Application.Json, typeof(AnyOf<string, StringPayload>), Description = "The string to echo.", Required = true)]
		[Consumes(typeof(AnyOf<string, StringPayload>), Application.Json, Text.Plain)]
		[Produces(Application.Json, Text.Plain)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            // _logger.LogInformation("C# HTTP trigger function processed a request.");

			var theString = req.Headers.ContainsKey(Value) ?
				req.Headers[Value].ToString() :
				req.ContentType switch
				{
					Application.Json => (await req.ReadRequestBodyAsAsync<StringPayload>()).Value,
					Text.Plain => await new StreamReader(req.Body).ReadToEndAsync(),
					_ => null
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
