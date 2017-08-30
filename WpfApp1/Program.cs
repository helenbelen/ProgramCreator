  
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

       //To Create An Instance of Program A name is Required
        public Program(string name)
        {
            programFeatures = new ArrayList();
            programName = name;
            sourcePathString = "";
            folderPathString = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs";
        
        }

        public Program (string name, string sourceFilePath, string programFolderPath)
        {
            programFeatures = new ArrayList();
            programName = name;
            sourcePathString = sourceFilePath;
            folderPathString = programFolderPath;
        }
        //Handles The Get & Set Of The Program Name
        public string Name 
        {
            get => programName;
            set => programName = value;
        }
        //Handles The Get & Set Of The Program Source File Path

        public string sourcePath
        {
            get => sourcePathString;
            set => sourcePathString = value;
        }

        //Handles The Get & Set Of The Program folder Path

        public string folderPath
        {
            get => folderPath;
            set => folderPath = value;
        }

        //This Method Adds Feature To Any Program
        public void addFeature (Feature newFeature)
        {
            try
            {
                //Check If Feature Is Already In The Array
                foreach (Feature f in programFeatures)
                {
                    if (f.Name == newFeature.Name)
                    {
                        Console.WriteLine("You Cannot Add The Same Feature More Than Once");
                        return;
                    }

                }
                
                
                programFeatures.Add(newFeature);
                
               
                
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);

            }
        }

        public void removeFeature (Feature newFeature)
        {
            try
            {
                if (programFeatures.Contains(newFeature))
                {
                    int i = programFeatures.IndexOf(newFeature);
                    programFeatures.RemoveAt(i);                    

                }
                else
                {
                    throw new ArgumentNullException("This Feature Is Not Apart Of This Program");
                }

            }
            catch
            {
                throw new ArgumentOutOfRangeException("Remove The Index Of The Feature Failed");
            }
           
        }

        public int numberOfFeatures() => programFeatures.Count;
        
    }
}
