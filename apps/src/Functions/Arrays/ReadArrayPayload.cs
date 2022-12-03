/*
 * ReadArrayPayload.cs
 *
 *   Created: 2022-12-02-10:20:38
 *   Modified: 2022-12-02-10:20:38
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Functions.Arrays;

public static class ReadArrayPayloadExtensions
{
    public static async Task<T[]> ReadArrayPayloadAsync<T>(this Req request)
    {
        try
        {
            var payload = await request.ReadFromJsonAsync<T[]>();
            return payload ?? throw new NullReferenceException("Payload was null");
        }
        catch
        {
            try
            {
                var payload = await request.ReadFromJsonAsync<ArrayPayload<T>>();
                return payload?.Values ?? System.Array.Empty<T>();
            }
            catch
            {
                return System.Array.Empty<T>();
            }
        }
    }
}
