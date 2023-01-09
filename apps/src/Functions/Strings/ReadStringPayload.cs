/*
 * ReadStringPayload.cs
 *
 *   Created: 2022-12-02-06:45:08
 *   Modified: 2022-12-02-06:45:08
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Reflection.Metadata.Ecma335;

namespace JustinWritesCode.Functions.Strings;

public static class ReadStringPayloadMethod
{
    public static async Task<string?> ReadStringPayloadAsync(this HttpRequest req)
    {
        try
        {
            if(req.GetContentType().Contains(TextMediaTypeNames.Plain, StringComparison.OrdinalIgnoreCase))
            {
                return await new StreamReader(req.Body).ReadToEndAsync();
            }
            else
            {
                try
                {
                    return req.ReadFromJsonAsync<StringPayload>().Result.Value;
                }
                catch
                {
                    return req.ReadFromJsonAsync<string>().Result;
                }
            }
        }
        catch
        {
            return default;
        }
    }
}
