using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Diagnostics;

namespace WpfApp1
{
    public class FileHandler
    {
        static FileInfo file;
        static FileStream fileStream;
        static StreamReader readStream;
        static StreamWriter writerStream;
        static CodeDomProvider codeProvider;
        static CompilerParameters parameters;
        static CompilerResults compilerResults;
        static string errorFile = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs\Errors.txt";





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

        public static bool CreateFile (Program program)
        {
            try
            {
               
                program.sourcePath = program.folderPathString + @"\" + program.Name + ".txt";
                fileStream = File.Create(program.sourcePath);
                fileStream.Close();
            }
            catch
            {
                System.Console.WriteLine("The Create Of " + program.Name + ".txt" + " Was Not Successful");
                return false;
            }

            return true;
        }

        public static string WriteCode (string fileName, string code)
        {
            file = new FileInfo(fileName);
            writerStream = file.CreateText();
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
                // Generate an executable instead of 
                // a class library.
                parameters.GenerateExecutable = true;
                // Set the assembly file name to generate.
                string OutputFile = f.Name + ".OutFile.exe";
                parameters.OutputAssembly = OutputFile;
                // Generate debug information.
                parameters.IncludeDebugInformation = true;
                // Add an assembly reference.
                parameters.ReferencedAssemblies.Add("System.dll");
                // Save the assembly as a physical file.
                parameters.GenerateInMemory = false;
                 // Set the level at which the compiler 
                // should start displaying warnings.
                parameters.WarningLevel = 3;
                 // Set whether to treat all warnings as errors.
                parameters.TreatWarningsAsErrors = false;
                 // Set compiler argument to optimize output.
                parameters.CompilerOptions = "/optimize";
                string myCode = getCode(f.sourcePath);
                compilerResults = codeProvider.CompileAssemblyFromSource(parameters, myCode);
                
                if (compilerResults.Errors.Count > 0)
                {
                    foreach (CompilerError error in compilerResults.Errors) { 
                    WriteCode(errorFile, "Line number " + error.Line +
                    ", Error Number: " + error.ErrorNumber +
                    ", '" + error.ErrorText + ";" +
                    Environment.NewLine + Environment.NewLine);
                    }
                    
                    return false;
                }
              
               
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Data);
                return false;
            }

            return true;
        }

        public string runCode(string executableString)
        {
            Process p = new Process();
            //Runs the program per the Process only
            p.StartInfo.UseShellExecute = false;
            //Set A Property That allows Us to read the Output
            p.StartInfo.RedirectStandardOutput = true;
            //Specifies the Excecutable File
            p.StartInfo.FileName = executableString;
            p.Start();

            // To avoid deadlocks, always read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output;
        }

    }
}
