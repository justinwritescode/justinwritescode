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
    public static class UriFragments
    {
        /// <summary>A URI fragment for <inheritdoc cref="UserId" path="/value/text()" /></summary>
        /// <value>user_id/</value>
        public const string UserId = "userid/";
        /// <summary>A URI fragment for <inheritdoc cref="Id" path="/value/text()" /></summary>
        /// <value>user_id/</value>
        public const string Id = "userid/";
        /// <summary>A URI fragment for <inheritdoc cref="Username" path="/value/text()" /></summary>
        /// <value>username/</value>
        public const string Username = "username/";
        /// <summary>A URI fragment for <inheritdoc cref="GivenName" path="/value/text()" /></summary>
        /// <value>givenname/</value>
        public const string GivenName = "givenname/";
        /// <summary>A URI fragment for <inheritdoc cref="Surname" path="/value/text()" /></summary>
        /// <value>surname/</value>
        public const string Surname = "surname/";
        /// <summary>A URI fragment for <inheritdoc cref="LanguageCode" path="/value/text()" /></summary>
        /// <value>languagecode/</value>
        public const string LanguageCode = "languagecode/";
        /// <summary>A URI fragment for <inheritdoc cref="IsBot" path="/value/text()" /></summary>
        /// <value>is_bot/</value>
        public const string IsBot = "is_bot/";
        /// <summary>A URI fragment for <inheritdoc cref="CanJoinGroups" path="/value/text()" /></summary>
        /// <value>can_join_groups/</value>
        public const string CanJoinGroups = "can_join_groups/";
        /// <summary>A URI fragment for <inheritdoc cref="CanReadAllGroupMessages" path="/value/text()" /></summary>
        /// <value>can_read_all_group_messages/</value>
        public const string CanReadAllGroupMessages = "can_read_all_group_messages/";
        /// <summary>A URI fragment for <inheritdoc cref="SupportsInlineQueries" path="/value/text()" /></summary>
        /// <value>supports_inline_queries/</value>
        public const string SupportsInlineQueries = "supports_inline_queries/";
    }
}
