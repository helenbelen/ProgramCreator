using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ConfirmPasswordState : State
    {
        LoginClass loginClass;
        public ConfirmPasswordState(LoginClass login)
        {
            this.loginClass = login;
        }


        public override string noPassword()
        {
            return "There is a password entered and submitted.";
        }
        public override string clearPassword()
        {

            return "Password cannot be cleared. Confirmation in process.";
        }

        public override string confirmPassword()
        {
            if (loginClass.comparePasswords())
            {

                loginClass.changeState(loginClass.GetPasswordConfirmedState());
                return "PASSWORD CONFIRMED";

            }
            else
            {
                loginClass.changeState(loginClass.getNoPasswordState());
                return "Password was incorrect. Please try again";

            }


        }

        public override string insertPassword(string password)
        {
            return "There is a password entered. Confirmation is Pending...";
        }

        public override string submitPassword()
        {

            return "Password Has Already Been Submitted.";
        }

        public override string printState()
        {
            return "CONFIRMPASSWORD";
        }
    }

 }
