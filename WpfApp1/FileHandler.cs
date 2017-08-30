using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp1
{
    public class FileHandler
    {
        FileInfo file;
        FileStream fileStream;
        StreamReader readStream;
        StreamWriter writerStream;

        public FileHandler() { }


        public string getCode (Feature feature)
        {
            string readString = "";
            string read;
           if(File.Exists(feature.featureSourcePathString))
            {

                readStream = File.OpenText(feature.featureSourcePathString);
                while ((read = readStream.ReadLine()) != null)
                {
                    readString += read;
                }
                readStream.Close();

            }

            return readString;
        }

        public bool CreateFile (Program program)
        {
            try
            {
                file = new FileInfo(program.Name + ".txt");
                fileStream = file.Create();
                program.sourcePathString = program.folderPathString + file.Name;
                fileStream.Close();
            }
            catch
            {
                System.Console.WriteLine("The Create Of " + file.Name + " Was Not Successful");
                return false;
            }

            return true;
        }

        public string WriteCode (string fileName, string code)
        {
            file = new FileInfo(fileName);
                    
            writerStream = file.CreateText();
            writerStream.WriteLine(code);
            writerStream.Close();
           
            return file.Name;

        }



    }
}
