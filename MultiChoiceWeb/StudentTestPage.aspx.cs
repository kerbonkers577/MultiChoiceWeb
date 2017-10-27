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
        //Test Questions
        private List<Question> testQ = new List<Question>();

        private string connectionString 
            = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();
        private SqlConnection dbConn;
        private DataAccess data = new DataAccess();
        private int itemCount;
        private int count = 0;
        private List<int> studentAnswers = new List<int>();


        int testCount = 0;
        int testItemCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = Session["stdName"].ToString();
            lblStudentNum.Text = Session["studentNum"].ToString();

            try
            {
                if(!Page.IsPostBack)
                {
                    dbConn = new SqlConnection(connectionString);

                    //Bringing up test details for information to the student
                    DataSet testInfo = data.GetSpecificTest(dbConn, Convert.ToInt16(Session["TestID"]));

                    object[] testInfoArray = testInfo.Tables[0].Rows[0].ItemArray;

                    lblTestName.Text = testInfoArray[1].ToString();
                    Session["TestName"] = testInfoArray[1].ToString();

                    //Filling Question List with question objects with values from database
                    //Get Test questions from selected test session token
                    DataSet questions = data.GetSpecificTestQuestions(dbConn, Convert.ToInt16(Session["TestID"]));
                    Question temp = new Question();

                    itemCount = questions.Tables[0].Rows.Count;

                    object[] itemGet;

                    for (int i = 0; i < itemCount; i++)
                    {
                        itemGet = questions.Tables[0].Rows[i].ItemArray;

                        //Get ID for adding it to studentAnswer table as FK
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
                        //Question array holds reference so temp must be reset to a new object
                        //otherwise it will change all stored questions
                        temp = new Question();
                    }

                    //Set values for each radio button for answer submission
                    //These are constant
                    rlStudentSelection.Items[0].Value = "1";
                    rlStudentSelection.Items[1].Value = "2";
                    rlStudentSelection.Items[2].Value = "3";
                    rlStudentSelection.Items[3].Value = "4";

                    //Heading
                    lblQuestionTitle.Text = testQ[0].GetQuestionText();

                    //These are the text values for the radio list, these change depending on the questions
                    rlStudentSelection.Items[0].Text = testQ[0].GetAnswer1Text();
                    rlStudentSelection.Items[1].Text = testQ[0].GetAnswer2Text();
                    rlStudentSelection.Items[2].Text = testQ[0].GetAnswer3Text();
                    rlStudentSelection.Items[3].Text = testQ[0].GetAnswer4Text();
                    
                    Session["Count"] = count;
                    Session["ItemCount"] = itemCount;
                    Session["testQuestions"] = testQ;
                    Session["StudentAnswers"] = studentAnswers;
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
                //Requires setting local variables to session states to change them
                //This is for adding values
                //and changing LCVs

                //Save answer
                studentAnswers = (List<int>)Session["StudentAnswers"];
                studentAnswers.Add(Convert.ToInt16(rlStudentSelection.SelectedItem.Value));
                Session["StudentAnswers"] = studentAnswers;

                //Increment counter
                count = Convert.ToInt16(Session["Count"]);
                count++;
                Session["Count"] = count;

                //If there are still questions
                if (Convert.ToInt16(Session["Count"]) < Convert.ToInt16(Session["ItemCount"]))
                {
                    //Change radio button text
                    testQ = (List<Question>)Session["testQuestions"];
                    
                    lblQuestionTitle.Text = testQ[Convert.ToInt16(Session["Count"])].GetQuestionText();
                    rlStudentSelection.Items[0].Text = testQ[Convert.ToInt16(Session["Count"])].GetAnswer1Text();
                    rlStudentSelection.Items[1].Text = testQ[Convert.ToInt16(Session["Count"])].GetAnswer2Text();
                    rlStudentSelection.Items[2].Text = testQ[Convert.ToInt16(Session["Count"])].GetAnswer3Text();
                    rlStudentSelection.Items[3].Text = testQ[Convert.ToInt16(Session["Count"])].GetAnswer4Text();

                }
                else
                {
                    int studentID = Convert.ToInt16(Session["stdID"]);
                    dbConn = new SqlConnection(connectionString);

                    testQ = (List<Question>)Session["testQuestions"];
                    studentAnswers = (List<int>)Session["StudentAnswers"];
                    //Adds Students answers to database with reference of question and test
                    for (int i = 0; i < testQ.Count; i++)
                    {
                        data.InsertStudentAnswer(dbConn, studentID, testQ[i].GetID(), studentAnswers[i]);
                    }

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