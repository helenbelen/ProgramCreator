using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FeatureIterator :IteratorInterface
    {
        Feature[] featureList;
        Feature currentFeature;
        int position = 0;
        public FeatureIterator(Feature [] programFeatures)
        {
            this.featureList = programFeatures;
            
        }


        public bool hasNext()
        {
            return position + 1 < featureList.Length ? true : false;
            
        }

        public Feature Next()
        {
            currentFeature = featureList[position];
            position++;
            return currentFeature;
        }

        
        public int containsFeature(string featureName)
        {
            for (int i = 0; i<featureList.Length; i++)
            {
                if (featureList[i].Name == featureName)
                {
                   
                    return i; 
                }

            }

            return -1;
        }
    }
}
