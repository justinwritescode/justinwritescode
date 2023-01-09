/*
 * FunctionsStartup.cs
 *
 *   Created: 2022-11-25-02:28:58
 *   Modified: 2022-11-25-02:28:58
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(JustinWritesCode.Functions.Numbers.Startup))]
