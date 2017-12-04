  
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1


{
    public class Program : Feature
    {
       
        private ArrayList programFeatures;
        private FeatureIterator iterator;

       //To Create An Instance of Program A name is Required
       public Program (string name, string folder) : base(name,folder)
        {
            programFeatures = new ArrayList();
            iterator = this.CreateIterator();
        
        }

       

        //This Method Adds Feature To Any Program
        public void addFeature (Feature newFeature)
        {
            
                //Check If Feature Is Already In The Array
                if (iterator.containsFeature(newFeature.Name) < 0) {

                    programFeatures.Add(newFeature);
                iterator = CreateIterator();
                }
          
        }

        public void removeFeature (Feature newFeature)
        {
            if (iterator.containsFeature(newFeature.Name) >= 0)
            {
                programFeatures.RemoveAt(iterator.containsFeature(newFeature.Name));
                iterator = CreateIterator();
            }
           
        }

        public int numberOfFeatures() => programFeatures.Count;

        public ArrayList GetFeatures() => programFeatures;

        public override FeatureIterator CreateIterator()
        {
            Feature[] featureArray = new Feature[programFeatures.Count];
            programFeatures.CopyTo(featureArray);
            return new FeatureIterator(featureArray);
        }

    }
}
