using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Twolayerproject
{
    public partial class userprofile : System.Web.UI.Page
    {
        connectionclass conobj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {


            string sel = "select name,age,address,photo from twolayer where id=" + Session["uid"] + "";
            SqlDataReader dr = conobj.Fn_Reader(sel);
            while(dr.Read())
            {
                TextBox1.Text = dr["Name"].ToString();
                TextBox2.Text = dr["Age"].ToString();
                TextBox3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["Photo"].ToString();
            }

            DataSet ds = conobj.Fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dt = conobj.Fn_DataTable(sel);
            DataList1.DataSource = ds;
            DataList1.DataBind();

                }
              
        }
    }
