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
            //List<int> ID = new List<int>();
            //List<string> names = new List<string>();
            
            //int tempID = 0;
            //string tempName = "";
            

            //int count = dataset.Tables[0].Rows.Count;

            //for (int i = 0; i < count; i++)
            //{
            //    object[] testDetails = dataset.Tables[0].Rows[i].ItemArray;

            //    for (int j = 0; j < testDetails.Length; j++)
            //    {
            //        tempID = Convert.ToInt16(testDetails[0]);
            //        tempName = testDetails[1].ToString();
                    
            //    }

            //    //testDict.Add(tempID, tempName);
            //    ID.Add(tempID);
            //    names.Add(tempName);
            //}

            
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
            
            if (test != -1)
            {
                Session["TestID"] = test;
                Response.Redirect("StudentTestPage.aspx");
            }
            else
            {
                lblTestSeelctErr.Text = "No Test has been selected";
            }
        }

        protected void lstTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            test = Convert.ToInt32(lstTests.SelectedValue);
            string stringTest = lstTests.SelectedItem.Text;
        }
    }
}