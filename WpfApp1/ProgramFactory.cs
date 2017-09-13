using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WpfApp1
{
    public abstract class ProgramFactory
    {
      

        public string GetProgramBeginning(Feature o) => o.getBeginningofFile();



        public string GetProgramEnding(Feature o) => o.getEndofFile();

        public abstract string CreateProgramCode();

        public abstract string CreateProgramFile(Feature f);


    
        

    }
}
