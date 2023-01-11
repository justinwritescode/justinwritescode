/*
 * Messages.cs
 *
 *   Created: 2022-12-19-07:53:35
 *   Modified: 2022-12-19-07:53:35
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Telegram.Constants;

public static class Messages
{
    /// <summary>The minimum length of a message caption.</summary>
    /// <value>0</value>
    public const int TextMinLength = 1;
    /// <summary>The maximum length of a message caption.</summary>
    /// <value>4096</value>
    public const int TextMaxLength = 4096;
    /// <summary>The minimum length of a message caption.</summary>
    /// <value>0</value>
    public const int CaptionMinLength = 0;
    /// <summary>The maximum length of a message caption.</summary>
    /// <value>1024</value>
    public const int CaptionMaxLength = 1024;
}
