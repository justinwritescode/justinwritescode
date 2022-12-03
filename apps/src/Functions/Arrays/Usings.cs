/*
 * Usings.cs
 *
 *   Created: 2022-11-25-07:53:03
 *   Modified: 2022-11-25-07:53:03
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


global using System.Net.Http.Headers;
global using static Microsoft.AspNetCore.Http.StatusCodes;
global using static Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiAuthLevelType;
global using static Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiVisibilityType;
global using Microsoft.Extensions.Logging;
global using Microsoft.Net.Http.Headers;
global using global::Microsoft.AspNetCore.Http;
global using global::Microsoft.AspNetCore.Mvc;
global using global::Microsoft.Azure.WebJobs;
global using global::Microsoft.Azure.WebJobs.Extensions.Http;
global using static global::Microsoft.Azure.WebJobs.Extensions.Http.AuthorizationLevel;
global using global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
global using global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
global using static global::Microsoft.OpenApi.Models.ParameterLocation;
global using static global::Microsoft.OpenApi.Models.SecuritySchemeType;
global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using static global::System.Net.Http.HttpRequestMethodNames;
global using static global::System.Net.HttpStatusCode;
global using static global::System.Net.Mime.MediaTypeNames;
global using global::System.Threading;
global using global::System.Threading.Tasks;
// global using JustinWritesCode.Http.Extensions;
// global using JProp = System.Text.Json.Serialization.JsonPropertyNameAttribute;
// global using Req = global::Microsoft.AspNetCore.Http.HttpRequest;
// global using OpAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiOperationAttribute;
// global using ParamAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiParameterAttribute;
// global using BodyAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiRequestBodyAttribute;
// global using ReqBodyAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiRequestBodyAttribute;
// global using RequestAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiRequestBodyAttribute;
// global using RequestBodyAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiRequestBodyAttribute;
// global using RespAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiResponseWithBodyAttribute;
// global using ResponseAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiResponseWithBodyAttribute;
// global using SecAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiSecurityAttribute;
// global using SecurityAttribute = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.OpenApiSecurityAttribute;
// global using SLoc = global::Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums.OpenApiSecurityLocationType;
// global using FunctionAttribute = global::Microsoft.Azure.WebJobs.FunctionNameAttribute;
// global using HttpAttribute = global::Microsoft.Azure.WebJobs.HttpTriggerAttribute;
// global using PLoc = global::Microsoft.OpenApi.Models.ParameterLocation;
global using Humanizer;
global using static JustinWritesCode.Functions.Arrays.Constants;
global using JustinWritesCode.Functions.Arrays.Payloads;
global using JustinWritesCode.Payloads;
global using JustinWritesCode.Payloads.Abstractions;
global using AuthLvl = Microsoft.Azure.WebJobs.Extensions.Http.AuthorizationLevel;
// global using JIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
// global using JPropAttribute = System.Text.Json.Serialization.JsonPropertyNameAttribute;
