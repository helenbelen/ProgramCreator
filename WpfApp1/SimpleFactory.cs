using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WpfApp1
{
    public class SimpleFactory : ProgramFactory
    {
        ArrayList newProgramFeatures;
        String code;
        Program newProgram;
        public SimpleFactory(Program p)
        {
            newProgramFeatures = new ArrayList(p.GetFeatures());
            newProgram = p;


        }

        public void makeProgram()
        {
            CreateProgramFile(newProgram);
        }

        public override string CreateProgramCode()
        {
            code = "";
            int numberofFeatures = newProgramFeatures.Count - 1;
            foreach (Feature f in newProgramFeatures)
            {
                if (newProgramFeatures.IndexOf(f) == 0)
                {
                    code = code + GetProgramBeginning(f);

                }
                else if (newProgramFeatures.Count - 1 == newProgramFeatures.IndexOf(f))
                {
                    code = code + GetProgramEnding(f);
                }
                else
                {
                    code = code + FileHandler.getCode(f.sourcePath);
                }


            }

            return code;


        }

        public override string CreateProgramFile(Feature f)
        {
            FileHandler.CreateFile(f);
            string s = FileHandler.WriteCode(f.sourcePath, CreateProgramCode());

            return FileHandler.WriteCode(f.sourcePath, CreateProgramCode());

        }
    }
}
