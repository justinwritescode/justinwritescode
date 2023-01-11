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

public static partial class ClaimTypes
{
    /// <summary>The base URI for Telegram - <inheritdoc cref="BaseUri" path="/value/text()" /></summary>
    /// <value>https://telegram.org/</value>
    public const string BaseUri = "https://telegram.org/";

    /// <summary>The base URI for Telegram identity - <inheritdoc cref="Identity" path="/value" /></summary>
    /// <value><inheritdoc cref="BaseUri" /><inheritdoc cref="Namespaces.Identity" /></value>
    public const string Identity = BaseUri + BaseUri;
    /// <summary>The URI for the Telegram user ID claim type.</summary>
    /// <value><inheritdoc cref="Identity" /><inheritdoc cref="UriFragments.UserId" /></value>
    public const string UserIdClaim = Identity + UriFragments.UserId;
    /// <summary>The URI for the Telegram <inheritdoc cref="UriFragments.Username" path="/value/text()" /> claim type.</summary>
    /// <value><inheritdoc cref="Identity" /><inheritdoc cref="UriFragments.Username" /></value>
    public const string Username = Identity + UriFragments.Username;
    /// <summary>The URI for the Telegram <inheritdoc cref="UriFragments.UserId" path="/value/text()" /> claim type.</summary>
    /// <value><inheritdoc cref="Identity" /><inheritdoc cref="UriFragments.UserId" /></value>
    public const string UserId = Identity + UriFragments.UserId;
}
