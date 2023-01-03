/*
 * Http403ForbiddenException.cs
 *
 *   Created: 2022-12-05-11:48:11
 *   Modified: 2022-12-05-11:49:05
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
namespace JustinWritesCode.Exceptions;

public class Http403ForbiddenException : Exception
{
    public const string DefaultMessage = "You do not have permission to access this resource.";

    public Http403ForbiddenException(string message = DefaultMessage) : base(message) { }
    public Http403ForbiddenException(string message = DefaultMessage, Exception? inner = default) : base(message, inner) { }

    public virtual ProblemDetails ToProblemDetails()
    {
        return new ProblemDetails
        {
            Title = "Forbidden",
            Status = 403,
            Detail = Message,
            Type = "https://en.wikipedia.org/wiki/HTTP_403"
        };
    }
}
