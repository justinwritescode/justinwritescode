/*
 * ArrayInsertPayload.cs
 *
 *   Created: 2022-11-25-06:52:14
 *   Modified: 2022-11-25-06:52:14
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

#pragma warning disable
namespace JustinWritesCode.Functions.Arrays.Payloads;

public struct ArrayChangePayload : IArrayPayload<string>
{
	public ArrayChangePayload() : this(System.Array.Empty<string>(), string.Empty) { }
	public ArrayChangePayload(string[] array, string value)
	{
		Array = array;
		Value = value;
	}

	[JProp("array")]
	public string[] Array { get; set; }

	[JIgnore]
	string[]  IPayload<string[]>.Value { get=> Array; set=> Array = value; }

	[JProp("value")]
	public string? Value { get; set; }

	[JProp("stringValue")]
	public string StringValue { get => string.Join(", ", Array); set { 	} }

    string[] IArrayPayload<string>.Values { get => Array; set => Array = value; }

    public int Count => Array.Length;
}
