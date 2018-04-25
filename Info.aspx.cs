using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Info : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=tss11;Initial Catalog=Vishal;User ID=sa;Password=sa123");
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "State";
            DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        

        if (RadioButton2.Checked == true)
        {
            conn.Open();
            // string str = "Insert into tbl_info values('" + DropDownList1.SelectedItem.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + RadioButton2.Text + "')";
            SqlCommand cmd = new SqlCommand("Insert into tbl_info values('" + DropDownList1.SelectedItem.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + RadioButton2.Text + "')", conn);
            cmd.ExecuteNonQuery();
            Label1.Text = "Record Inserted";
            conn.Close();
            Clear();
        }
        if (RadioButton3.Checked == true)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into tbl_Info values ('" + DropDownList1.SelectedItem + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3 + ",'" + RadioButton3.Text + "')", conn);
            cmd.ExecuteNonQuery();
            Label1.Text = "Record Inserted";
            conn.Close();
            Clear();
        }
    }
    public void Clear()
    {
       
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        conn.Open();
        string str = "Update tbl_Info set Name = '" + TextBox1.Text + "',Address='" + TextBox2.Text + "',Phone_No='" + TextBox3.Text + "',Gender='" + RadioButton2.Text + "' Where State ='" + DropDownList1.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "select * from tbl_Info where state='"+DropDownList1.SelectedItem.Text+"'";
        SqlCommand cmd = new SqlCommand(str, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
    
        while (reader.Read())
        {
            TextBox1.Text=reader["Name"].ToString();
            TextBox2.Text = reader["Address"].ToString();
            TextBox3.Text = reader["Phone_No"].ToString();
       }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {

        conn.Open();
        String str="Delete From tbl_Info Where State='"+DropDownList1.SelectedItem.Text+"'";
        SqlCommand cmd = new SqlCommand(str,conn);
        cmd.ExecuteNonQuery();
        Label1.Text = "Record Inserted";

    }
}