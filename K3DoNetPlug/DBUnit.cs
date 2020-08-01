using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace K3DoNetPlug
{
    public class DBUnit
    {
        public static string GlobalConnString { get; private set; }

        //public BaseChecker Checker { get; private set; }

        public BaseLister Lister { get; private set; }

        public BaseClassLister BaseLister { get; private set; }

        internal static void InitGlobalConnString(string connString)
        {
            GlobalConnString = connString;
        }

        public DBUnit(BaseBiller biller)
        {
            this.Biller = biller;
        }

        public DBUnit(BaseLister baseLister)
        {
            this.Lister = baseLister;
        }

        public DBUnit(BaseClassLister baseClassLister)
        {
            this.BaseLister = baseClassLister;
        }

        //public DBUnit(BaseChecker checker)
        //{
        //    this.Checker = checker;
        //}

        /// <summary>
        /// k3login
        /// </summary>
        /// <contractEntity name="propsString">样式ConnectString={Persist Security Info=True;Provider=SQLOLEDB.1;User ID=sa;Password=123456;Data Source=CHEETAHING-PC;Initial Catalog=Develop};UserName=administrator;UserID=16394;DBMS Name=Microsoft SQL Server;DBMS Version=2000/2005;SubID=super;AcctType=gy;Setuptype=Industry;Language=chs;IP=192.168.1.251;K3Version=KUE;MachineName=CHEETAHING-PC;UUID=BAD160C5-B4DB-4965-A8A7-0D373C885AE6</contractEntity>
        public DBUnit(string propsString)
        {
            this._connString = GetNewBillConstring(propsString);
        }

        public BaseBiller Biller { get; private set; }

        /// <summary>
        /// 去除sql查录参数中的单引号，防注入
        /// </summary>
        /// <contractEntity name="argument"></contractEntity>
        /// <returns></returns>
        public static string VeriflySql(string argument)
        {
            return argument.Replace("'", "''");
        }

        #region 获取连接字符串
        private string _connString;
        public string ConnString 
        { 
            get
            {
                if (string.IsNullOrEmpty(_connString))
                {
                    if (this.Lister!=null||this.BaseLister!=null)
                    {
                        this._connString = GetNewBillConstring(VBDoNetPlugInstance.GetNewBillerInstance().GetPropsString());
                    }
                    else if (Biller.BillerType == TypeBiller.OldBiller)
                    {
                        //匹配标准连接字符串
                        k3BillTransfer.Bill oldBiller = this.Biller.M_BillTransfer as k3BillTransfer.Bill;
                        this._connString = Regex.Replace(oldBiller.Cnnstring, @"Provider=.*?;", "", RegexOptions.None);
                    }
                    else
                    {
                        this._connString = GetNewBillConstring(VBDoNetPlugInstance.GetNewBillerInstance().GetPropsString());
                    }
                }
//#if DEBUG
//                System.Windows.Forms.MessageBox.Show(this._connString);
//#endif
                return _connString;
            }
        }
        #endregion

        private string GetNewBillConstring(string propsString)
        {
            //匹配标准连接字符串
            Match collection = Regex.Match(propsString, @"ConnectString=\{(?<connString>.+)\}");//提取连接字符串
            return Regex.Replace(collection.Groups["connString"].ToString(), @"Provider=.*?;", "", RegexOptions.None);//剔除Provider项，生成标准连接串
        }

        public void Run(string command)
        {
            SqlConnection conn=new SqlConnection(this.ConnString);
            SqlCommand comm=new SqlCommand(command,conn);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Run(string command,params string[] argument)
        {
            this.Run(string.Format(command, argument));
        }

        public void Run(string command, out DataTable table)
        {
            SqlConnection conn = new SqlConnection(this.ConnString);
            SqlDataAdapter sda = new SqlDataAdapter(command, conn);
            table = new DataTable();
            sda.Fill(table);
        }

        public void Run(string command,out DataTable table,params string[] argument)
        {
            this.Run(string.Format(command, argument), out table);
        }

        public bool Exist(string command)
        {
            SqlDataReader reader;
            SqlConnection conn = new SqlConnection(this.ConnString);
            SqlCommand sqlComm = new SqlCommand(command, conn);
            try
            {
                conn.Open();
                reader = sqlComm.ExecuteReader();
                return reader.HasRows;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Exist(string command, string[] argument)
        {
            return this.Exist(string.Format(command, argument));
        }
    }
}
