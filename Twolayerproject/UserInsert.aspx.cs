using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Twolayerproject
{
    public partial class UserInsert : System.Web.UI.Page
    {
        connectionclass conobj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));

            string str= "insert into twolayer values('"+TextBox1.Text+"',"+TextBox2.Text+",'"+TextBox3.Text+"','"+ path+ "','"+TextBox4.Text+"','"+TextBox5.Text+"')";
            int i = conobj.Fn_Nonquery(str);
            if (i==1)
            {
                Label7.Text = "Inserted Successfully";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
           

        }
    }
}