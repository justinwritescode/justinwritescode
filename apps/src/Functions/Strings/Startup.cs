/*
 * Startup.cs
 *
 *   Created: 2022-11-26-06:22:49
 *   Modified: 2022-11-26-06:22:50
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

 [assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(JustinWritesCode.Functions.Strings.Startup))]

namespace JustinWritesCode.Functions.Strings;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public class Startup : FunctionsStartup
{
	public override void Configure(IFunctionsHostBuilder builder)
	{
		builder.Services.AddLogging();
		builder.Services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
		{
			var options = new OpenApiConfigurationOptions()
			{
				Info = new OpenApiInfo()
				{
					Version = "0.0.1",
					Title = "JustinWritesCode Strings API",
					Description = "This API is used by front-end bot services to process requests to manipulate arrays because the bot front-ends don't.",
					// TermsOfService = new Uri("https://github.com/Azure/azure-functions-openapi-extension"),
					Contact = new OpenApiContact()
					{
						Name = "Justin Chase",
						Email = "justin@justinwritescode.com",
						Url = new ("https://github.com/justinwritescode"),
					},
					License = new OpenApiLicense()
					{
						Name = "MIT",
						Url = new ("http://opensource.org/licenses/MIT"),
					}
				},
				Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
				OpenApiVersion = OpenApiVersionType.V2,
				IncludeRequestingHostName = true,
				ForceHttps = false,
				ForceHttp = false,
			};

			return options;
		});
	}
}
