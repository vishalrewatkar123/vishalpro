using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class City : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=tss11;Initial Catalog=Vishal;User ID=sa;Password=sa123");
    SqlDataReader dr = null;
    string strSqlCmd = string.Empty;

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
        ddlCountry.Items.Insert(0, new ListItem("---Select", "0"));
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da1 = new SqlDataAdapter();
        ddlState.Items.Clear();
        String str = "select State from tbl_State where Cid= " + ddlCountry.SelectedItem.Value;

        cmd = new SqlCommand(str, conn);
        da1 = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ddlState.DataTextField = "State";
        ddlState.DataValueField = "State";

        da1.Fill(dt);
        ddlState.DataSource = dt;


        ddlState.DataBind();





       
                                                                                                                                                                                                                                                    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select State_Id from tbl_State where State= '" + ddlState.SelectedValue + "'", conn);
        int i = (Int32)cmd.ExecuteScalar();

        string a = txtCity.Text;
        string str = "insert into tbl_City values('" + a + "','" + i + "')";
        SqlCommand cmd1 = new SqlCommand(str, conn);
        cmd1.ExecuteNonQuery();
       // string b = "Select Country_Name,State, City_Name From tbl_Country1 As c, tbl_State as s, tbl_City as cs Where c.Country_Id= s.Cid AND s.State_Id = cs.State_Id";
        //string b = "Select * from tbl_Country1";
        SqlDataAdapter da = new SqlDataAdapter("Select C.Country_Name, S.State, ca.City_Name from tbl_Country1 c, tbl_State s, tbl_City ca Where c.Country_Id= s.Cid And s.State_id=ca.State_Id", conn);
        DataSet ds = new DataSet();
          DataTable dt = new DataTable();
         // DataSet ds = new DataSet();
          da.Fill(dt);
          GridView1.DataSource = dt;
          GridView1.DataBind();
        Label1.Text="Records are Inserted";

      
    }
}
    // int i = (Int32)cmd.ExecuteScalar();

        
      //string b = "Select Country_Name,State, City_Name From tbl_Country1 As c, tbl_State as s, tbl_City as cs Where c.Country_Id= s.Cid AND s.State_Id = cs.State_Id";