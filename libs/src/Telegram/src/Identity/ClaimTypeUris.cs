/*
 * Claims.cs
 *
 *   Created: 2022-12-15-11:25:21
 *   Modified: 2022-12-15-11:25:21
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Telegram.Identity;

public static class ClaimTypeUris
{
    /// <summary><inheritdoc cref="TelegramID.BaseUri" /></summary>
    /// <value><inheritdoc cref="TelegramID.BaseUri" /></value>
    public static readonly Uri BaseUri = new(TelegramID.BaseUri);

    /// <summary><inheritdoc cref="TelegramID.Identity" /></summary>
    /// <value><inheritdoc cref="TelegramID.Identity" /></value>
    public static readonly Uri Identity = new(TelegramID.Identity);
}
