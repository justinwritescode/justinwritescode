using System.IO;
using System.Net.Mime.MediaTypes;
/*
* Remove.cs
*
*   Created: 2022-11-26-06:17:58
*   Modified: 2022-11-26-06:17:58
*
*   Author: Justin Chase <justin@justinwritescode.com>
*
*   Copyright © 2022-2023 Justin Chase, All Rights Reserved
*      License: MIT (https://opensource.org/licenses/MIT)
*/

#pragma warning disable
namespace JustinWritesCode.Functions.Arrays;

public class RemoveFromArray
{
	[Function(nameof(RemoveFromArray))]
	[Op(operationId: nameof(RemoveFromArray), tags: new[] { Tags.Arrays, Tags.Mutations })]
	[Param(name: Headers.XChangeCase, In = Header, Required = false, Type = typeof(LetterCasing), Description = "The case to apply to the array values")]
	[Param(name: Headers.XValue, In = Header, Required = false, Type = typeof(string))]
	[RequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(ArrayChangePayload), Required = true, Description = "The array to remove the value from and the value to remove")]
	[ProducesResponseType(typeof(ArrayResponsePayload<string>), Status200OK)]
	public static async Task<IActionResult> InsertAsync(
	[Http(AuthLvl.Anonymous, Post, Route = Routes.Remove)] Req req)
	{
		var payload = await req.ReadFromJsonAsync<ArrayChangePayload>().ConfigureAwait(false)!;
		var casing = req.GetQueryStringEnum(Headers.XChangeCase, LetterCasing.LowerCase);
		var newArray = payload.Array.Except(new[] {payload.Value}, StringComparer.OrdinalIgnoreCase).Where(x => x is not null).Select(x => x.ApplyCase(casing)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToArray();
		var responsePayload = new ArrayResponsePayload<string>(newArray);
		return new OkObjectResult(responsePayload);
	}
}
