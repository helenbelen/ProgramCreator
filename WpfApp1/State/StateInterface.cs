using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface StateInterface
    {
        string noPassword();
        string insertPassword(string password);
        string clearPassword();
        string submitPassword();
        string confirmPassword();
       
        string printState();
    }
}
