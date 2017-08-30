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

        public string Name
        {
            get => featureName;
            set => featureName = value;
        }

        public string sourcePath
        {
            get => featureSourcePathString;
            set => featureSourcePathString = value;
        }

        public string folderPath
        {
            get => featureFolderString;
            set => featureFolderString = value;
            
        }

       
        

    }
}
