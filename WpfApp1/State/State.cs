using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class State : StateInterface
    {
        public virtual string clearPassword()
        {
            throw new NotImplementedException();
        }

        public virtual string confirmPassword()
        {
            throw new NotImplementedException();
        }

        public virtual string insertPassword(string password)
        {
            throw new NotImplementedException();
        }

        public virtual string noPassword()
        {
            throw new NotImplementedException();
        }

        public virtual string submitPassword()
        {
            throw new NotImplementedException();
        }

        
        public virtual string printState()
        {
            throw new NotImplementedException();
        }
    }
}
