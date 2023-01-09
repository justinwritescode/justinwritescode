/*
 * ClaimsPrincipalExtensions.cs
 *
 *   Created: 2023-01-06-06:09:24
 *   Modified: 2023-01-06-06:09:24
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Telegram.Identity;
using System.Linq;
using System.Security.Claims;
public static class ClaimsPrincipalExtensions
{
    public static long GetTelegramId(this ClaimsPrincipal principal)
    {
        return principal.Claims
            .Where(c => c.Type == TelegramID.UserId)
            .Select(c => long.Parse(c.Value))
            .FirstOrDefault();
    }

    public static long GetTelegramUsername(this ClaimsPrincipal principal)
    {
        return principal.Claims
            .Where(c => c.Type == TelegramID.Username)
            .Select(c => long.Parse(c.Value))
            .FirstOrDefault();
    }
}
