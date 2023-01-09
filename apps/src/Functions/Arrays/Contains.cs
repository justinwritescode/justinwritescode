/*
 * Contains.cs
 *
 *   Created: 2022-12-02-03:03:05
 *   Modified: 2022-12-02-03:03:05
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Functions.Arrays;

public class Contains
{
    [Function(nameof(Contains))]
    [Op(operationId: nameof(Contains), tags: new[] { Tags.Arrays, Tags.Query })]
    [Param(name: Headers.XValue, Description = "The value to search for", Type = typeof(string), In = Header | Query, Required = true)]
    [Param(name: HReqH.Accept, Description = "The acceptable response type", Type = typeof(string), In = Header, Required = false)]
    [RequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(ArrayPayload<string>), Required = true, Description = "The array in which to check for the value")]
    [ResponseBody(statusCode: OK, contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(BooleanResponsePayload), Description = "True if the value is in the array, false otherwise")]
    public static async Task<IActionResult> ContainsAsync(
        [Http(AuthLvl.Anonymous, Post, Route = Routes.Contains)] Req req)
    {
        var payload = await req.ReadArrayPayloadAsync<string>().ConfigureAwait(false);
        var value = req.GetHeaderParam<string>(Headers.XValue) ?? req.GetQueryStringParam<string>("value");
        var contains = payload.Contains(value);

        var accept = req.Headers.TryGetValue(HReqH.Accept, out var acceptHeader)
            ? acceptHeader.ToString()
            : ApplicationMediaTypeNames.Json;
        return req.HttpContext.FormatResponse<bool>(contains);
    }
}
