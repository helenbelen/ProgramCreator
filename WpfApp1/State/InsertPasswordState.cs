using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class InsertPasswordState : State
    {
        private LoginClass loginClass;
        public InsertPasswordState(LoginClass login)
        {
            this.loginClass = login;
        }

        public override string noPassword()
        {
          return "There is a password entered.";
        }
        public override string clearPassword()
        {
            loginClass.insertNewPassword("");
            loginClass.changeState(loginClass.getNoPasswordState());
            return "Password Has Been Cleared";
        }

        public override string confirmPassword()
        {
            
            return "You Must Submit The Password Before It Can Be Confirmed";
        }

        public override string insertPassword(string password)
        {
            return "There is a password entered. Please clear the current password or submit it for confirmation.";
        }

        public override string submitPassword()
        {
            
            loginClass.changeState(loginClass.GetConfirmPasswordState());
            return "Password Submitted.";
        }

        
        public override string printState()
        {
            return "INSERTPASSWORD";
        }
    }
}
