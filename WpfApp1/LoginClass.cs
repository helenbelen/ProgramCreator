using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class LoginClass
    {
        private State NOPASSWORD;
        private State INSERTPASSWORD;
        private State CONFIRMPASSWORD;
        private State PASSWORDCONFIRMED;
        private static string PASSWORD;
        private string submittedPassword;
        private State LoginState;
      
        public LoginClass(string newPassword){

            PASSWORD = newPassword;
            
            NOPASSWORD = new NoPasswordState(this);
            INSERTPASSWORD = new InsertPasswordState(this);
            CONFIRMPASSWORD = new ConfirmPasswordState (this);
            PASSWORDCONFIRMED = new PasswordConfirmedState(this);
            LoginState = NOPASSWORD;
        }

        public string noPassword()
        {
            return LoginState.noPassword();
        }
        public string clearPassword()
        {

            return LoginState.clearPassword();
        }

       
        public string insertPassword(string password)
        {
            
            return LoginState.insertPassword(password);
        }

     
        public string confirmPassword()
        {
            return LoginState.confirmPassword();
        }
           

        public string submitPassword()
        {
            return LoginState.submitPassword();
        }

        

        public bool comparePasswords() => submittedPassword == PASSWORD ? true : false;

        public void insertNewPassword(string password) => submittedPassword = password;

        public void changeState(State newState)
        {
            LoginState = newState;
        }
        public State getState() => this.LoginState;

        public State getNoPasswordState() => NOPASSWORD;

        public State getInsertPasswordState() => INSERTPASSWORD;
        
        public State GetConfirmPasswordState() => CONFIRMPASSWORD;

        public State GetPasswordConfirmedState() => PASSWORDCONFIRMED;
    }
}
