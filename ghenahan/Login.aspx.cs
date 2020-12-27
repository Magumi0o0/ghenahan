using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ghenahan.DAL;

namespace ghenahan
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccessLayer dal;
        protected void Page_Load(object sender, EventArgs e)
        {
            dal = new DataAccessLayer();
            
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            int adId = Convert.ToInt32(Application["adId"]);
            string email = Txtemail.Text;
            string password = txtpassword.Text;
            var user = dal.SelectData($"select * from Users where E_mail = '{email}' and Pass = '{password}'");
            if (user.Rows.Count == 0)
            {
                Response.Write("<script>alert('Information Error')</script>");
                return;
            }
            Session["UserId"] = user.Rows[0][0];
            Session["UserName"] = user.Rows[0][1];
            Session["UserDept"] = user.Rows[0][6];
            var userDept = user.Rows[0][6];
            int userDeptId = Convert.ToInt32(userDept);
            if (userDeptId == adId)
            {
                Response.Redirect("Admin.aspx");
                return;
            }
            Response.Redirect("Student.aspx");
        }
    }
}