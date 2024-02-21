using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinalProjectASP
{
    public partial class User_Home : System.Web.UI.Page
    {
        connectionclass ob = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sel = "select * from Category where Category_Status='Available'";
                DataSet ds = ob.Fn_DataSet(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int caid = Convert.ToInt32(e.CommandArgument);
            Session["catid"] = caid;
            Response.Redirect("View_Products.aspx");
        }
    }
}