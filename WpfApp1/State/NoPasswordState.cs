using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class NoPasswordState : State 
    {
        LoginClass loginClass;
        public NoPasswordState(LoginClass login)
        {
            this.loginClass = login;
        }


        public override string noPassword()
        {
            return "Please Enter A Password";
        }
        public override string clearPassword()
        {
            return "There is no password. Please Enter A Password";
        }

        public override string confirmPassword()
        {
            return "There is no password. Please Enter A Password";
        }

        public override string insertPassword(string password)
        {
            loginClass.insertNewPassword(password);
            loginClass.changeState(loginClass.getInsertPasswordState());
            return "Thank You For Inserting Password";
        }

        public override string submitPassword()
        {
            return "There is no password. Please Enter A Password";
        }
        
        public override string printState()
        {
            return "NOPASSWORD";
        }
    }
}
