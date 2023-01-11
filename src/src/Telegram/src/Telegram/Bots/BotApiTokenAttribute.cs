/*
 * BotApiTokenAttribute.cs
 *
 *   Created: 2022-12-05-06:14:46
 *   Modified: 2022-12-05-06:15:25
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Telegram.Bot.Types;

using System.ComponentModel.DataAnnotations;

public class BotApiTokenAttribute : RegularExpressionAttribute
{
    public BotApiTokenAttribute() : base(BotApiToken.RegexString) { }
}
