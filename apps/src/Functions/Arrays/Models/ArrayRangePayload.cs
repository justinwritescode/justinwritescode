// 
// ArrayRangePayload.cs
// 
//   Created: 2022-09-21-07:47:16
//   Modified: 2022-11-05-12:33:04
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Functions.Arrays.Models;
using System.Collections.Generic;

public class ArrayRangePayload : ArrayPayload
{
    public List<string> Range { get; set; } = new();
}
