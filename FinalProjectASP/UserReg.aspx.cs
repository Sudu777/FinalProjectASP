using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectASP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        connectionclass ob = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Registration_Id)from Login";
            string regid = ob.Fn_Scalar(sel);
            int reg_id = 0;
            if(regid=="")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string ins="insert into User_Tab values("+reg_id+",'"+TextBox1.Text+"',"+TextBox2.Text+",'"+TextBox3.Text+"',"+TextBox4.Text+",'"+TextBox5.Text+"','"+RadioButtonList1.SelectedItem.Text+"','"+TextBox6.Text+"','"+DropDownList1.SelectedItem.Text+"','"+TextBox8.Text+"','active')";
            int i = ob.Fn_Nonquery(ins);

            if(i!=0)
            {
                Label1.Text = "You Have Been Registered";
                string inslog = "insert into Login values(" + reg_id + ",'" + TextBox9.Text + "','" + TextBox10.Text + "','user','active')";
                ob.Fn_Nonquery(inslog);
                Response.Redirect("Login.aspx");
            }
        }
    }
}