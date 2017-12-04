using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;

namespace ProgramCreatorTest
{
    [TestClass]
    public class LoginTest
    {

        LoginClass login;

        public void TestSetUp()
        {
            login = new LoginClass("password");

            
        }
        [TestMethod]
        public void StateChangesCorrectly()
        {
            this.TestSetUp();
            login.noPassword();
            login.clearPassword();
            login.insertPassword("pass");
            login.submitPassword();
            login.confirmPassword();

            string actualState = login.getState().printState();
            string expectedState = "NOPASSWORD";
            Assert.AreEqual(expectedState, actualState, "State changes are not occuring properly");
        }

       
    }
}
