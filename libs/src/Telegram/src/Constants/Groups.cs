/*
 * Groups.cs
 *
 *   Created: 2022-12-19-07:51:02
 *   Modified: 2022-12-19-07:51:03
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Telegram.Constants;

public static class GroupsAndChannels
{
    /// <summary>The minimum length of a group title.</summary>
    /// <value>5</value>
    public const int TitleMinLength = 5;
    /// <summary>The maximum length of a group title.</summary>
    /// <value>128</value>
    public const int TitleMaxLength = 128;
    /// <summary>The minimum length of a group description.</summary>
    /// <value>0</value>
    public const int DescriptionMinLength = 0;
    /// <summary>The maximum length of a group description.</summary>
    /// <value>255</value>
    public const int DescriptionMaxLength = 255;
    /// <summary>The minimum length of a group username.</summary>
    /// <value>5</value>
    public const int UsernameMinLength = 5;
    /// <summary>The maximum length of a group username.</summary>
    /// <value>32</value>
    public const int UsernameMaxLength = 32;
}
