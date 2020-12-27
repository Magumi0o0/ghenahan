using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ghenahan.DAL;
namespace ghenahan
{
    public partial class AddStudent : System.Web.UI.Page
    {
        DataAccessLayer dal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 dal = new DataAccessLayer();
                int adminId = Convert.ToInt32(Application["adId"]);
                var students = dal.SelectData($"select Users.Id , Users.Name , Users.Last_Name, Users.Birth , Users.E_mail , Users.Pass ," +
                                                          $" Depts.[Name] from Users , Depts where Users.DID = Depts.Id And DID <>  {adminId}");
                gdview.DataSource = students;
                gdview.DataBind();

            }

            dal = new DataAccessLayer();
            var depts = dal.SelectData("Select * from Depts Where Name <> 'Admin'");
            DropDownList1.DataSource = depts;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();

        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            string UserName = txtName.Text;
            string LastName = txtLastName.Text;
            string Birth = Convert.ToDateTime(txtBirth.Text).ToShortDateString();
            string Email = txtMail.Text;
            string Password = txtPaas.Text;
            int DeptId = Convert.ToInt32(DropDownList1.Text);
            dal.Open();
            dal.ExecuteCommand($"INSERT INTO USERS VALUES('{UserName}' , '{LastName}' , '{Birth}' , '{Email}' , '{Password}', {DeptId})");
            dal.Close();
           


        }

        protected void gdview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}