  
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
        public string programName, sourcePathString, folderPathString;
        private ArrayList programFeatures;

       //To Create An Instance of Program A name is Required
       public Program (string name, string folder) : base(name,folder)
        {
            programFeatures = new ArrayList();
            folderPathString = folder;
        
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

        public ArrayList GetFeatures() => programFeatures;

        
                 
    }
}
