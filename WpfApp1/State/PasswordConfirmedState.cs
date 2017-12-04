using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class PasswordConfirmedState :State
    {
        LoginClass loginClass;
        public PasswordConfirmedState(LoginClass login)
        {
            this.loginClass = login;
        }

        public override string noPassword()
        {
            return "Password has been confirmed.";
        }
        public override string clearPassword()
        {
            
            return "Password has been confirmed and cannot be cleared.";
        }

        public override string confirmPassword()
        {
            return "Password has been confirmed.";
        }

        public override string insertPassword(string password)
        {
            return  "Password has already been confirmed.";
        }

        public override string submitPassword()
        {
            return "Password has been confirmed and another password cannot be submitted.";
        }

        public override string printState()
        {
            return "PASSWORDCONFIRMED";
        }

    }
}
