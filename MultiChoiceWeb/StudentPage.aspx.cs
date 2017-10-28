using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MultipleChoiceLibrary;

namespace MultiChoiceWeb
{
    public partial class StudentPage : System.Web.UI.Page
    {
        private static string connectionString = 
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();

        private SqlConnection dbConn = new SqlConnection(connectionString);
        private DataAccess data = new DataAccess();
        private static Dictionary<int, string> testDict = new Dictionary<int, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtStdName.Text = Session["stdName"].ToString();
            txtStdNum.Text = Session["studentNum"].ToString();
            try
            {
                DataSet tests = data.GetTestTable(dbConn);
                listFill(tests);
            }
            catch (SqlException ex)
            {
                
            }
        }

        protected void btnViewMarks_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpecificStudentMark.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["studentNum"] = "";
            Response.Redirect("Home.aspx");
        }

        public void listFill(DataSet dataset)
        {
            if(!Page.IsPostBack)
            {
                lstTests.DataSource = dataset;
                lstTests.DataValueField = "test_ID";
                lstTests.DataTextField = "test_Name";

                lstTests.DataBind();
            }
            

        }


        int test;
        protected void btnTestSelect_Click(object sender, EventArgs e)
        {
            //TODO:
            //Check if student has already taken test
            //Use Marks table
            //If student has got marks for test, then he has taken the test
            try
            {
                dbConn = new SqlConnection(connectionString);
                int studentID = Convert.ToInt16(Session["stdID"]);
                DataSet markCheck = data.GetStudentMarkForTest(dbConn, studentID, test);

                object[] arrMarkCheck = null;
                bool markFlag = false;

                if(markCheck.Tables[0].Rows.Count != 0)
                {
                    arrMarkCheck = markCheck.Tables[0].Rows[0].ItemArray;

                    if (arrMarkCheck[0] != null)
                    {
                        markFlag = true;
                    }
                }
                


                if (markFlag == false && test != -1)
                {
                    Session["TestID"] = test;
                    Response.Redirect("StudentTestPage.aspx");
                }
                else
                {
                    if (markFlag == true)
                    {
                        lblTestSeelctErr.Text = "Test already completed";
                    }
                    else
                    {
                        lblTestSeelctErr.Text = "No Test has been selected";
                    }

                }
            }
            catch(IndexOutOfRangeException ex)
            {
                //Will occur when student has no marks and arrMarkCheck will not be filled
            }
            catch(SqlException ex)
            {

            }
            
        }

        protected void lstTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            test = Convert.ToInt32(lstTests.SelectedValue);
            string stringTest = lstTests.SelectedItem.Text;
        }
    }
}