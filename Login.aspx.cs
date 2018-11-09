using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void LoginButton_Click(object sender, EventArgs e)
    //{
       

    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = "Data Source=.; initial catalog=; integrated security=true";
    //    con.Open();

    //    SqlCommand cmd = new SqlCommand();
    //    cmd.Connection = con;
    //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //    cmd.CommandText =;
    //    cmd.Parameters.AddWithValue("@Username", )
    //    cmd.ExecuteNonQuery();



    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FormsAuthentication.Authenticate(TextBox1.Text, TextBox2.Text))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=.; initial catalog=SmsDB; integrated security=true";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Users";
                cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text);

                cmd.ExecuteReader();
                Response.Redirect("Admin/NewAdmission.aspx");
            }
            else
            {
                Response.Write("invalid ");
            }
            

        }
        catch (Exception)
        {

            Response.Write("Error");
        }
        
    }
}