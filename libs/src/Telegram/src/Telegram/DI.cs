/*
 * DI.cs
 *
 *   Created: 2022-12-15-01:46:44
 *   Modified: 2022-12-15-01:46:45
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

/*
 * DI.cs
 *
 *   Created: 2022-12-14-02:03:20
 *   Modified: 2022-12-14-02:03:20
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Telegram.Bot.Types;

#if NET6_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
#endif

public static class TelegramBotDIExtensions
{
    // public static readonly Action<SwaggerGenOptions> ConfigureSwaggerGen = options =>
    //    {
    //        try
    //        {
    //            options.MapType<BotApiToken>(() => new OpenApiSchema
    //            {
    //                Type = "string",
    //                Pattern = BotApiToken.RegexString,
    //                Format = nameof(BotApiToken),
    //                Description
    //                        = "A BotApiToken is a 64-bit integer value with a 35-character alphanumeric string separated by a colon.",
    //                Example = new OpenApiString("1234567890:ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
    //            });
    //        }
    //        catch (ArgumentException)
    //        {
    //            // ignore
    //        }
    //    };

#if NET6_0_OR_GREATER

    public static WebApplicationBuilder DescribeBotApiToken(this WebApplicationBuilder builder)
    {
        builder.Services.Describe<BotApiToken>();//.ConfigureSwaggerGen(ConfigureSwaggerGen);
        return builder;
    }

#endif

    public static IServiceCollection DescribeBotApiToken(this IServiceCollection services)
    {
        services.Describe<BotApiToken>();
        return services;
    }
}
