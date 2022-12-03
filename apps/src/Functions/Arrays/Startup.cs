/*
 * Startup.cs
 *
 *   Created: 2022-11-25-08:31:03
 *   Modified: 2022-11-25-08:31:03
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

[assembly:Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(JustinWritesCode.Functions.Arrays.Startup))]
// [assembly: Microsoft.Azure.WebJobs.Hosting.WebJobsStartup(typeof(AzureFunctions.ModelBinding.FunctionModelBindingStartup))]


#pragma warning disable
namespace JustinWritesCode.Functions.Arrays;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
// using Serilog;

public class Startup : FunctionsStartup
{
	public override void Configure(IFunctionsHostBuilder builder)
	{
        // var logger = new LoggerConfiguration()
        //     .WriteTo.Console()
        //     .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        //     .CreateLogger();
        // builder.Services.AddLogging(builder => builder.AddSerilog(logger));
        builder.Services.AddLogging();
        // builder.Services.AddHttpBindingRouting();
        // builder.Services.AddMvcCore().AddFunctionModelBinding();
        // builder.AddExtension<FunctionModelBindingExtensionConfigProvider>();
		builder.Services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
		{
            return new OpenApiConfigurationOptions()
            {
                Info = new OpenApiInfo()
                {
                    Version = "0.0.1",
                    Title = "JustinWritesCode Arrays API",
                    Description = "This API is used by front-end bot services to process requests to manipulate arrays because the bot front-ends don't.",
                    // TermsOfService = new Uri("https://github.com/Azure/azure-functions-openapi-extension"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Justin Chase",
                        Email = "justin@justinwritescode.com",
                        Url = new Uri("https://github.com/justinwritescode"),
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("http://opensource.org/licenses/MIT"),
                    }
                },
                Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
                OpenApiVersion = OpenApiVersionType.V2,
                IncludeRequestingHostName = true,
                ForceHttps = false,
                ForceHttp = false,
            };
		});
	}
}
