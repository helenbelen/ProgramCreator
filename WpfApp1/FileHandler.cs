using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections;

namespace WpfApp1 { 



    public static class FileHandler
    {
       
        static FileStream fileStream;
        static StreamReader readStream;
        static StreamWriter writerStream;
        static CodeDomProvider codeProvider;
        static CompilerParameters parameters;
        static CompilerResults compilerResults;
        static string errorFile = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Errors.txt";


        public static ArrayList filesInDirectory (String folderPath, ArrayList fileList)
        {
            try
            {
               
                var files = Directory.EnumerateFiles(folderPath, "*.txt", SearchOption.AllDirectories);
                 foreach(string filename in files)
                {
                    //Adds only the name of the file to the array list not the whole path
                    int  nameLength = (filename.Length + 1) - (folderPath.Length + 1);
                    if(filename.Substring(folderPath.Length + 1, nameLength - 1) != "Test.txt" && filename.Substring(folderPath.Length + 1, nameLength - 1) != "TestCheck.txt" && filename.Substring(folderPath.Length + 1, nameLength - 1) != "Errors.txt")
                         fileList.Add(filename.Substring(folderPath.Length +1, nameLength-1));

                        
                }

              }
            catch (UnauthorizedAccessException accessException)
            {
                WriteCode(errorFile, accessException.Message);
                Console.WriteLine(accessException.Message);
            }
            catch (PathTooLongException pathException)
            {
                WriteCode(errorFile, pathException.Message);
                Console.WriteLine(pathException.Message);
            }
            return fileList;
        }


        public static string getCode (string filePath)
        {
            string readString = "";
            string read;
           if(File.Exists(filePath))
            {

                readStream = File.OpenText(filePath);
                while ((read = readStream.ReadLine()) != null)
                {
                    readString += read;
                }
                readStream.Close();

            }

            return readString;
        }

        public static string removeExtensions(string nameWithExtension)
        {
            return nameWithExtension.Split('.')[0];
           
        }

        public static bool CreateFile (Feature feature)
        {
            try
            {
                feature.sourcePath = feature.folderPath + @"\" + feature.Name + ".txt";
                if (!File.Exists(feature.sourcePath))
                {
                    
                    fileStream = File.Create(feature.sourcePath);
                    fileStream.Close();
                }
                
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message.ToString());
                System.Console.WriteLine("The Create Of " + feature.Name  + " Was Not Successful " + e.Message);
                return false;
            }

            return true;
        }

        public static bool deleteFile (Feature feature)
        {
            if (!File.Exists(feature.sourcePath))

            {

                return false;
            }
            
            try
            {
                
                File.Delete(feature.sourcePath);
                if (File.Exists(feature.outputPath))
                {
                    File.Delete(feature.outputPath);
                }
            }
            catch (Exception ex)
            {
                WriteCode(errorFile, Environment.NewLine + ex.Data);

            }
            return true;
        }

        public static string WriteCode (string fileName, string code)
        {
            
            writerStream = (new FileInfo(fileName)).CreateText();
            writerStream.Write(code);
            writerStream.Close();
           
            return fileName;

        }

        public static bool CompileCode (Feature f)
        {

            try
            {

                codeProvider = CodeDomProvider.CreateProvider("CSharp");
                parameters = new CompilerParameters();
                parameters.GenerateExecutable = true;
                string OutputFile = f.Name + ".OutFile.exe";
                parameters.OutputAssembly = OutputFile;
                parameters.IncludeDebugInformation = true;
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.GenerateInMemory = false;
                parameters.WarningLevel = 3;
                parameters.TreatWarningsAsErrors = false;
                parameters.CompilerOptions = "/optimize";
                string myCode = getCode(f.sourcePath);
                compilerResults = codeProvider.CompileAssemblyFromSource(parameters, myCode);
                
                if (compilerResults.Errors.Count > 0)
                {
                    foreach (CompilerError error in compilerResults.Errors) { 
                    WriteCode(errorFile, Environment.NewLine + "Line number " + error.Line +
                    ", Error Number: " + error.ErrorNumber +
                    ", '" + error.ErrorText + ";" +
                    Environment.NewLine);
                    }
                    
                    return false;
                }
                f.outputPath = OutputFile;

            }
            catch (Exception e)
            {
                WriteCode(errorFile, e.Data.ToString());
                
                return false;
            }

            
            return true;
        }

        public static string runCode(string executableString)
        {
            string output = "";

            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = executableString;
                
                
                    p.Start();

                    output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                
             
            }
            catch(FileNotFoundException e)
            {
                WriteCode(errorFile, e.Data.ToString());
                Console.Write(e.Data);
            }
            catch (InvalidOperationException e)
            {
                WriteCode(errorFile, e.Data.ToString());
                Console.Write(e.Data);
            }

            return output;
        }

    }
}
