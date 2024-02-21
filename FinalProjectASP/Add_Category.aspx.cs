using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectASP
{
    public partial class Add_Category : System.Web.UI.Page
    {
        connectionclass ob = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "";
            s = "~/Category_Images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));

            string sel = "insert into Category values('" + TextBox1.Text + "','" + s + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = ob.Fn_Nonquery(sel);
            if(i!=0)
            {
                Label1.Text = "Category Successfully Added";
            }

        }
    }
}