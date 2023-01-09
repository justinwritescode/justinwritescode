/*
 * Usernames.cs
 *
 *   Created: 2022-12-19-07:47:28
 *   Modified: 2022-12-19-07:47:29
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Reflection;

namespace Telegram.Constants;

public static class Account
{
    public const int UsernameMinLength = 5;
    public const int UsernameMaxLength = 32;
    public const int GivenNameMinLength = 0;
    public const int GivenNameMaxLength = 64;
    public const int SurnameMinLength = 0;
    public const int SurnameMaxLength = 0;
}
