﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
public partial class Alogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        this.txtut.Text = "Admin";
        SqlCommand cmd = new SqlCommand("select count(*)from Users where username = '" + txtUsername.Text + "'and password= '" + txtPassword.Text + "'and usertype= '" + txtut.Text + "'", con);
        int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        if (count > 0)
        {
            SqlCommand cmdType = new SqlCommand("select usertype from Users where username = '" + txtUsername.Text + "'", con);
            string uType = cmdType.ExecuteScalar().ToString().Replace(" ", "");
            Session["uType"] = uType;
            Response.Redirect("Adminf.aspx");
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Login Fail!";
        }
        con.Close();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }
}