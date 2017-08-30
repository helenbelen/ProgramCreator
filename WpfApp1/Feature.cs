using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Feature       
    {
        public string featureName, featureSourcePathString, featureFolderString;

       //Features Must Have A Name At Minimum
        public Feature (string name)
        {
            featureName = name;
            featureSourcePathString = "";
            featureFolderString = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features";

        }

        public Feature (string name, string featureSourcePath, string featureFolderPath)
        {
            featureName = name;
            featureSourcePathString = featureSourcePath;
            featureFolderString = featureFolderPath;
        }
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

       
        

    }
}
