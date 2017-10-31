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
    public partial class DataMasterPage : System.Web.UI.Page
    {
        private DataAccess data = new DataAccess();
        private SqlConnection dbConn;
        private static string connectionString =
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();

        //This page is a requirement of the POE
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get all Tables (Raw)
                dbConn = new SqlConnection(connectionString);

                DataSet tests = data.GetTestTable(dbConn);
                DataSet teachers = data.GetTeacherTable(dbConn);
                DataSet questions = data.GetQuestionTable(dbConn);
                DataSet students = data.GetStudentTable(dbConn);
                DataSet studentAnswers = data.GetStudentAnswerTable(dbConn);
                DataSet studentMarks = data.GetStudentMarkTable(dbConn);

                //Bind their datasets to applicable table

                grdTest.DataSource = tests;
                grdTest.DataBind();

                grdTeacher.DataSource = teachers;
                grdTeacher.DataBind();

                grdQuestion.DataSource = questions;
                grdQuestion.DataBind();

                grdStudent.DataSource = students;
                grdStudent.DataBind();

                grdStudentAnswer.DataSource = studentAnswers;
                grdStudentAnswer.DataBind();

                grdStudentMark.DataSource = studentMarks;
                grdStudentMark.DataBind();

            }
            catch(SqlException ex)
            {
                Session["Error"] = "The following error occurred : \n" + ex.Message.ToString() + " : " + ex.ToString();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}