/*
 * Startup.cs
 *
 *   Created: 2022-11-22-04:38:22
 *   Modified: 2022-11-22-04:38:29
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Functions.Numbers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using AnyOfTypes.System.Text.Json;
using Path = System.IO.Path;

public class Startup : FunctionsStartup
{
	public override void Configure(IFunctionsHostBuilder builder)
	{
		builder.Services.AddLogging();
		Console.WriteLine("Registered the logger.");
	}

	public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
	{
		FunctionsHostBuilderContext context = builder.GetContext();
		builder.ConfigurationBuilder
        	.AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
		    .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false);
	}
}
