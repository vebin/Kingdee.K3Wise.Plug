using System;
using System.Collections.Generic;
using System.Text;
using k3Login;
using System.Text.RegularExpressions;
namespace K3DoNetPlug
{
    public class K3Login
    {
        internal bool IsLogin = false;
        public DBUnit DBUnitInstance;

        public string UserName;

        public string UserID;

        public bool Login()
        {
            k3Login.ClsLogin clsLogin = new ClsLogin();
            this.IsLogin = clsLogin.CheckLogin();
            if (IsLogin)
            {
                this.DBUnitInstance = new DBUnit(clsLogin.PropsString);
                this.InitUserInfo(clsLogin.PropsString);
            }
            return this.IsLogin;
        }

        private void InitUserInfo(string propsString)
        {
            Match match = Regex.Match(propsString, "UserName=(?<UserName>.*?);UserID=(?<UserID>.*?);");
            UserName = match.Groups["UserName"].Value;
            UserID = match.Groups["UserID"].Value;
        }
    }
}
