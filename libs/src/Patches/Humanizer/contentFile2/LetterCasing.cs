/*
 * LetterCasing.cs
 *
 *   Created: 2022-11-29-01:02:15
 *   Modified: 2022-11-29-01:02:15
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Humanizer
{
	/// <summary>
	/// Options for specifying the desired letter casing for the output string
	/// </summary>
	[Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
	public enum LetterCasingForOpenApi
	{
		/// <summary>
		/// SomeString -> Some String
		/// </summary>
		[System.Runtime.Serialization.EnumMember(Value = "title")]
		Title,
		/// <summary>
		/// SomeString -> SOME STRING
		/// </summary>
        [System.Runtime.Serialization.EnumMember(Value = "all-caps")]
		AllCaps,
		/// <summary>
		/// SomeString -> some string
		/// </summary>
        [System.Runtime.Serialization.EnumMember(Value = "lowercase")]
		LowerCase,
		/// <summary>
		/// SomeString -> Some string
		/// </summary>
        [System.Runtime.Serialization.EnumMember(Value = "sentence")]
		Sentence,
	}
}
