  
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1


{
    public class Program
    {
        public string programName, sourcePathString, folderPathString;
        public ArrayList programFeatures;

        
        public Program()
        {
            programName = "";
            sourcePathString = "";
            folderPathString = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs";
        }

        public Program(string name)
        {
            programName = name;
            sourcePathString = "";
            folderPathString = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs";
        
        }

        public Program (string name, string sourceFilePath, string programFolderPath)
        {
            programName = name;
            sourcePathString = sourceFilePath;
            folderPathString = programFolderPath;
        }

        public string Name 
        {
            get => programName;
            set => programName = value;
        }

        public string sourcePath
        {
            get => sourcePathString;
            set => sourcePathString = value;
        }

        public string folderPath
        {
            get => folderPath;
            set => folderPath = value;
        }

        public void addFeature (Feature newFeature)
        {
            try
            {
                programFeatures.Add(newFeature);
            }
            catch
            {
                if(newFeature == null)
                {
                    throw new ArgumentNullException("The Feature Is Null and Cannot be added");
                }
                else
                {
                    throw new ArgumentException("The Feature Is NOT Null but Another Error Prevented The Feature From Being Added");
                }
                
            }
        }

        public void removeFeature (Feature newFeature)
        {
            if (programFeatures.Contains(newFeature))
            {
                programFeatures.Remove(newFeature);
            }
            else
            {
                Console.Write("This Feature Is Not Apart Of This Program");
            }
        }

        public int numberOfFeatures() => programFeatures.Count;
        
    }
}
