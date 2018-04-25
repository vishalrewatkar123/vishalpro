using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Country : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(" Data Source=tss11;Initial Catalog=Vishal;User ID=sa;Password=sa123");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Insert into tbl_Country1 values ('" + txtcountry1.Text + "')", conn);
        cmd.ExecuteNonQuery();
        Label1.Text = "Record Inserted";
        conn.Close();
        Response.Redirect("~/State.aspx");

    }
}