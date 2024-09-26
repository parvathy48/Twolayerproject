using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Twolayerproject
{
    public partial class Login : System.Web.UI.Page
    {
        connectionclass conobj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select count(ID) from twolayer where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string s = conobj.Fn_Scalar(sel);
            if(s=="1")
            {
                int id1 = 0;
                string sel1= "select ID from twolayer where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                //string s1 = conobj.Fn_Scalar(sel1);
                SqlDataReader dr = conobj.Fn_Reader(sel1);
                while(dr.Read())
                {
                    id1 = Convert.ToInt32(dr["id"].ToString());
                }
                Session["uid"] = id1; 
                Response.Redirect("userprofile.aspx");
            }
            else
            {
                Label3.Text = "Invalid Username and Password";
            }
        }
    }
}