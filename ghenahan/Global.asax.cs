using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ghenahan.DAL;

namespace ghenahan
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            DataAccessLayer dal = new DataAccessLayer();
            dal.Open();

            var depts = dal.SelectData("SELECT * FROM Depts");
            if (depts.Rows.Count == 0)
            {
                dal.ExecuteCommand("INSERT INTO Depts VALUES('Admin')");
                dal.ExecuteCommand("INSERT INTO Depts VALUES('SOFTWARE')");
                dal.ExecuteCommand("INSERT INTO Depts VALUES('NETWORKS')");
                dal.ExecuteCommand("INSERT INTO Depts VALUES('COMPUTERS')");
            }
            
            var Admin = dal.SelectData("SELECT * FROM Users");
            if (Admin.Rows.Count == 0)
            {
                var Dept = dal.SelectData("SELECT Id FROM Depts WHERE Name = 'Admin'");
                var dptRows = Dept.Rows[0][0];
                var AdminDeptId = Convert.ToInt32(dptRows);
                dal.ExecuteCommand("INSERT INTO Users VALUES('ghena' , 'kalam' ,  '06/18/1999' ,'ghena@tcc.com' , '123456', " + AdminDeptId + ")");
            }
            var adId = dal.SelectData("SELECT Id FROM Depts WHERE Name = 'Admin'");
            var adIdIdRows = adId.Rows[0][0];
            Application["adId"] = adIdIdRows;
            var swId = dal.SelectData("SELECT Id FROM Depts WHERE Name = 'SOFTWARE'");
            var swIdRows = swId.Rows[0][0];
            Application["swId"] = swIdRows;
            var nwId = dal.SelectData("SELECT Id FROM Depts WHERE Name = 'NETWORKS'");
            var nwIdRows = nwId.Rows[0][0];
            Application["nwId"] = nwIdRows;
            dal.Close();
        }   
    }
}