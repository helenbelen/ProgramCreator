using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Feature     
    {
        public string featureName, featureSourcePathString, featureFolderString,outputFileString;
        public static string FILE_BEGINNING_STRING;
        public static string FILE_ENDING_STRING = "}}}";


        //Features Must Have A Name At Minimum
        public Feature(string name, string folder)
        {
            featureName = name;
            featureFolderString = folder;
            featureSourcePathString = "";
            FILE_BEGINNING_STRING = "using System; namespace " +  name + "{public class " + name + " {public static void Main(){";
            FileHandler.CreateFile(this);
        }


        public string getBeginningofFile() => FILE_BEGINNING_STRING;
        public string getEndofFile() => FILE_ENDING_STRING;
     
        //Handles The Get & Set Of Feature Name
        public string Name
        {
            get => featureName;
            set => featureName = value;
        }

        //Handles The Get & Set Of Feature Source Path

        public string sourcePath
        {
            get => featureSourcePathString;
            set => featureSourcePathString = value;
        }

        //Handles The Get & Set Of Feature Folder Path

        public string folderPath
        {
            get => featureFolderString;
            set => featureFolderString = value;
            
        }

        public string outputPath
        {
            get => outputFileString;
            set => outputFileString = value;

        }




    }
}
