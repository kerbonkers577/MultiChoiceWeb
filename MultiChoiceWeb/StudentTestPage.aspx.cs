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
    public partial class StudentTestPage : System.Web.UI.Page
    {
        private List<Question> testQ = new List<Question>();
        private string connectionString 
            = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();
        private SqlConnection dbConn;
        private DataAccess data = new DataAccess();
        private int itemCount;
        private int count;
        private List<int> studentAnswers = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = Session["stdName"].ToString();
            lblStudentNum.Text = Session["studentNum"].ToString();

            try
            {
                dbConn = new SqlConnection(connectionString);

                if(!Page.IsPostBack)
                {
                    
                    //Bringing up test details for information to the student
                    DataSet testInfo = data.GetSpecificTest(dbConn, Convert.ToInt16(Session["TestID"]));

                    object[] testInfoArray = testInfo.Tables[0].Rows[0].ItemArray;

                    lblTestName.Text = testInfoArray[1].ToString();

                    //Filling Question List with question objects with values from database
                    //Get Test questions from selected test session token
                    DataSet questions = data.GetSpecificTestQuestions(dbConn, Convert.ToInt16(Session["TestID"]));
                    Question temp = new Question();

                    itemCount = questions.Tables[0].Rows.Count;
                    object[] itemGet;

                    for (int i = 0; i < itemCount; i++)
                    {
                        itemGet = questions.Tables[0].Rows[i].ItemArray;

                        temp.SetQuestionID(Convert.ToInt16(itemGet[0]));
                        //Skip test ID as we already have it
                        //Sets Quesiton text to temp question object
                        temp.SetQuestionText(itemGet[2].ToString());
                        //Sets answer text
                        temp.SetAnswer1Text(itemGet[3].ToString());
                        temp.SetAnswer2Text(itemGet[4].ToString());
                        temp.SetAnswer3Text(itemGet[5].ToString());
                        temp.SetAnswer4Text(itemGet[6].ToString());
                        temp.SetActualAnswer(Convert.ToInt16(itemGet[7]));

                        testQ.Add(temp);
                    }

                    //Set values for each radio button for answer submission
                    //These are constant
                    rlStudentSelection.Items[0].Value = "1";
                    rlStudentSelection.Items[1].Value = "2";
                    rlStudentSelection.Items[2].Value = "3";
                    rlStudentSelection.Items[3].Value = "4";

                    //These are the text values for the radio list, these change depending on the questions
                    rlStudentSelection.Items[0].Text = testQ[0].GetAnswer1Text();
                    rlStudentSelection.Items[1].Text = testQ[0].GetAnswer2Text();
                    rlStudentSelection.Items[2].Text = testQ[0].GetAnswer3Text();
                    rlStudentSelection.Items[3].Text = testQ[0].GetAnswer4Text();

                    count++;
                }

            }
            catch(SqlException)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rlStudentSelection.SelectedItem != null)
            {
                if (itemCount < count)
                {
                    //Change radio button text
                    rlStudentSelection.Items[0].Text = testQ[count].GetAnswer1Text();
                    rlStudentSelection.Items[1].Text = testQ[count].GetAnswer2Text();
                    rlStudentSelection.Items[2].Text = testQ[count].GetAnswer3Text();
                    rlStudentSelection.Items[3].Text = testQ[count].GetAnswer4Text();

                    //Save answer
                    studentAnswers.Add(Convert.ToInt16(rlStudentSelection.SelectedItem.Value));

                    //Increment counter
                    count++;
                }
                else
                {
                    Response.Redirect("Memo.aspx");
                }
            }
            else
            {
                lblRadioError.Text = "No option was selected";
            }
            
            
        }
    }
}