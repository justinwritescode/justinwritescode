/*
 * ApplyCase.cs
 *
 *   Created: 2022-11-29-02:36:30
 *   Modified: 2022-11-29-02:36:30
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
extern alias Humanizr;
using System;

namespace Humanizer;

//
// Summary:
//     ApplyCase method to allow changing the case of a sentence easily
public static class CasingExtensions
{
    public static string ApplyCase(this string input, LetterCasingForOpenApi casing) => input.ApplyCase((LetterCasing)casing);
}
