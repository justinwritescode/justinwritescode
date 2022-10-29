#!/usr/bin/env ts-node

import process from 'process';
import * as fs from "fs";
import path from "path";

var inputFile = process.argv.slice(2)[0];
var inputFileContents = fs.readFileSync(inputFile, 'utf8').split("\n");
var inputFileContentsNoHeader:string[] = [];
var inComment = false;
var foundComment = false;
for(var i = 0; i < inputFileContents.length; i++)
{
    var line = inputFileContents[i];
    console.log(`line: ${line}`);
    if(line.startsWith("<!--    "))
    {
        inComment = true;
    }
    else if(line.startsWith("    ") && inComment)
    {
        // do nothing
    }
    else if(line.startsWith("-->") && inComment)
    {
        inputFileContentsNoHeader = inputFileContents.slice(i + 1);
        console.log(`Found end of header at line ${i}`);
        foundComment = true;
        break;
    }
    else
    {
        continue;
    }
}
const header = `<!--    
    ${path.basename(inputFile)}
    
    Author: Justin Chase <justin@justinwritescode.com>
    
    MIT License
    
    Copyright © 2022 Justin Chase <justin@justinwritescode.com>, All Riqhts Reserved.
    
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the \"Software\"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
-->
`;

fs.writeFileSync(inputFile, header + (foundComment ? inputFileContentsNoHeader.join("\n") : inputFileContents), 'utf8');
