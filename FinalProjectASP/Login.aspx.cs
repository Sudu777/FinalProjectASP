using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectASP
{
    public partial class Login : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Registration_Id) from Login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "')";
            string cid = obj.Fn_Scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Registration_Id from Login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "')";
                string regid = obj.Fn_Scalar(str1);
                Session["userid"] = regid;
                string str2 = "select Login_Type from Login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "')";
                string logtype = obj.Fn_Scalar(str2);
                if (logtype == "Admin")
                {
                    Label1.Text = "Admin";
                    Response.Redirect("Admin_Home");
                }
                else if (logtype == "user")
                {
                    Label1.Text = "User";
                }


            }
        }
    }
}


       