using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultipleChoiceLibrary;
using System.Data;
using System.Data.SqlClient;

namespace MultiChoiceWeb
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        private string studentNum;
        private string password;
        private static string connectionString = 
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();

        public string StudentNum
        {
            get
            {
                return studentNum;
            }
            set
            {
                studentNum = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private DataAccess data = new DataAccess();
        private SqlConnection dbConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dbConn = new SqlConnection(connectionString);
            }
            catch(SqlException ex)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            StudentNum = txtStudentNum.Text;
            Password = txtPassword.Text;

            //If student exists, move to next form
            if (Page.IsValid && data.CheckSpecificStudentLogin(dbConn, studentNum, password) == true)
            {
                Session["studentNum"] = txtStudentNum.Text;
                DataSet name = data.GetSpecificStudent(dbConn, studentNum);
                object [] names = name.Tables[0].Rows[0].ItemArray;

                Session["stdName"] = names[1].ToString();
                Response.Redirect("StudentPage.aspx");
            }
            else
            {
                lblError.Text = "Invalid login credentials";
            }
            
        }

    }
}