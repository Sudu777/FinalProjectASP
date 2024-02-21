using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinalProjectASP
{
    public partial class View_Products : System.Web.UI.Page
    {
        connectionclass ob = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sel = "select * from Product where Category_Id="+Session["catid"]+"";
                DataSet ds = ob.Fn_DataSet(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int proid = Convert.ToInt32(e.CommandArgument);
            Session["pid"] = proid;
            Response.Redirect("Product.aspx");
        }
    }
}