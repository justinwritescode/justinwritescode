/*
 * Http404NotFoundException.cs
 *
 *   Created: 2022-12-05-11:47:13
 *   Modified: 2022-12-05-11:47:14
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
namespace JustinWritesCode.Exceptions;

public class Http404NotFoundException : HttpExceptionBase
{
    public const string DefaultMessage = "The requested item could not be found.";
    public Http404NotFoundException(string message = DefaultMessage) : base(message) { }
    public Http404NotFoundException(string message = DefaultMessage, Exception? inner = null) : base(message, inner) { }

    public override ProblemDetails ToProblemDetails() 
    {
        return new ProblemDetails
        {
            Title = "Not Found",
            Status = 404,
            Detail = Message,
            Type = "https://en.wikipedia.org/wiki/HTTP_404"
        };
    }
}
