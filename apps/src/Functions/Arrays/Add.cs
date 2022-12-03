/*
 * Insert.cs
 *
 *   Created: 2022-11-25-06:46:13
 *   Modified: 2022-11-25-06:46:13
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

#pragma warning disable
using System.Net.Mime.MediaTypes;

namespace JustinWritesCode.Functions.Arrays;


public class AddToArray
{
	[Function(nameof(AddToArray))]
	[Op(operationId: nameof(AddToArray), tags: new[] { Tags.Arrays, Tags.Mutations })]
	[Param(name: Headers.XChangeCase, In = Header, Required = false, Type = typeof(LetterCasing))]
	[Param(name: Headers.XValue, In = Header, Required = false, Type = typeof(string))]
    [RequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(ArrayChangePayload), Required = true, Description = "The array to insert the value into and the value to insert")]
	[ProducesResponseType(typeof(ArrayResponsePayload<string>), Status200OK)]
	public static async Task<IActionResult> InsertAsync(
	[Http(AuthLvl.Anonymous, Post, Route = Routes.Insert)] Req req)
	{
		var payload = await req.ReadFromJsonAsync<ArrayChangePayload>().ConfigureAwait(false)!;
		var casing = req.GetHeaderEnum(Headers.XChangeCase, LetterCasing.LowerCase);
        payload.Value = string.IsNullOrEmpty(payload.Value) ? req.GetHeaderParam<string>(Headers.XValue, payload.Value) : payload.Value;
		var newArray = payload.Array.Append(payload.Value).Where(x => x is not null).Select(x => x.ApplyCase(casing)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToArray();
		// var responsePayload = new ArrayResponsePayload<string>(newArray);
		return req.HttpContext.FormatResponse<string[]>(newArray);
	}
}
