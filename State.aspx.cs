using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class State : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=tss11;Initial Catalog=Vishal;User ID=sa;Password=sa123");
    SqlDataReader dr = null;
    string str = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string str = "select * from tbl_country1 ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "Country_Name";
            ddlCountry.DataValueField = "Country_Id";
            ddlCountry.DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select Country_Id from tbl_Country1 where Country_Name='" + ddlCountry.SelectedItem + "'", conn);
        int i = (Int32)cmd1.ExecuteScalar();
     
     
         
        SqlCommand cmd = new SqlCommand("Insert into tbl_State values('" + txtstate1.Text + "','" +i+ "')", conn);
        cmd.ExecuteNonQuery();
        Response.Redirect("~/City.aspx");
        conn.Close();
    }
}

//  int i = (Int32)cmd1.ExecuteScalar();
//int i = (Int32)cmd1.ExecuteScalar();