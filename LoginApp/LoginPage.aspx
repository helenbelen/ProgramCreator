<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LoginApp.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <link rel="stylesheet" href="styles.css"/>
</head>
<body>
    <form id="form1" action="/action_page.php">
        

        <div class="container">
            <label><b>Username</b></label>
            <input type="text" placeholder="Enter Username" name="uname"/>

            <label><b>Password</b></label>
            <input type="password" placeholder="Enter Password" name="psw"/>

            <button type="submit">Login</button>
           
        </div>

        <div class="container" style="background-color: #f1f1f1">
            <button type="button" class="cancelbtn">Cancel</button>
            <span class="psw">Forgot <a href="#">password?</a></span>
        </div>
    </form>
 
</body>
</html>
