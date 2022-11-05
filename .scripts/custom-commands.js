// 
// custom-commands.ts
// 
//   Created: 2022-11-03-02:34:46
//   Modified: 2022-11-03-02:34:47
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

const vscode = require("vscode");

exports.Copy_Text = async (vscode, args, editorProps, output) => {
  let currentFilePath = args?.fsPath // ! Can be undefined
  const { editor, document, selection, textRange, editorText, selectedText, variables } = editorProps // ! Can be an empty object

const {
    workspaceFolder,
    workspaceFolderBasename,
    currentFile,
    file,
    fileWorkspaceFolder,
    relativeFile,
    relativeFileDirname,
    fileBasename,
    fileBasenameNoExtension,
    fileDirname,
    fileExtname,
    pathSeparator
  } = variables; // predefined variables which can also be used to run shell commands
  
  vscode.env.clipboard.writeText("Copy Text");
  vscode.window.showInformationMessage('Copied command to the clipboard 📋');
  
  output.appendLine("Copied command to the clipboard 📋") // this will be logged under `Custom Commands Log` output panel in vscode
}

exports.Npm_Version = "npm -v" // direct string value will be executed as a shell commands

exports.Run_File = "node ${currentFile}" // can use predefined variables

// exports.Generate_Solution = async(vscode, args, editorProps, output) => {
//     vscode.window.showInformationMessage('Generating solution...');
//     output.appendLine("Generating solution...") // this will be logged under `Custom Commands Log` output panel in vscode
//     const { editor, document, selection, textRange, editorText, selectedText, variables } = editorProps // ! Can be an empty object
//     const { workspaceFolder, workspaceFolderBasename, currentFile, file, fileWorkspaceFolder, relativeFile, relativeFileDirname, fileBasename, fileBasenameNoExtension, fileDirname, fileExtname, pathSeparator } = variables; // predefined variables which can also be used to run shell commands
//     const { exec } = require("child_process");
//     return `slngen ${file}`; // run shell command
// }

exports.Generate_Solution = "slngen ${currentFile}"; // run shell command
