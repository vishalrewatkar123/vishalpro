using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Information : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=tss11;Initial Catalog=Vishal;User ID=sa;Password=sa123");
    protected void Page_Load(object sender, EventArgs e)
    {/*
        if (!IsPostBack)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Information1", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Country";
            DataBind();
        }*/
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (RadioButton1.Checked == true)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Information1 values('" + DropDownList1.SelectedItem.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + RadioButton1.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            clear();
        }
        if (RadioButton2.Checked == true)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Information1 values ('" + DropDownList1.SelectedItem + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3 + ",'" + RadioButton2.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            clear();
        }
        
        
    }
    public void clear()
    {
        TextBox1.Text="";
        TextBox2.Text="";
        TextBox3.Text="";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        conn.Open();
        string str = "Update Information1 set Name = '" + TextBox1.Text + "',Address='" + TextBox2.Text + "',Phone_No='" + TextBox3.Text + "',Gender='" + RadioButton1.Text + "' Where Country='" + DropDownList1.SelectedItem + "'";
        SqlCommand cmd = new SqlCommand(str, conn);
        cmd.ExecuteNonQuery();
       }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        conn.Open();
        string str = "Delete From Information1 where Country ='" + DropDownList1.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand(str, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
          
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

        string str = "select * from Information1 where Country='" + DropDownList1.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand(str, conn);
        conn.Open();
        SqlDataReader r = cmd.ExecuteReader();

        while (r.Read())
        {
            TextBox1.Text = r["Name"].ToString();
            TextBox2.Text = r["Address"].ToString();
            TextBox3.Text = r["Phone_No"].ToString();
        }

    }
}