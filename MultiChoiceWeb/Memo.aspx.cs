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
    public partial class Memo : System.Web.UI.Page
    {
        private List<int> studentAnswers = new List<int>();
        private SqlConnection dbConn;
        private string connectionString = 
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();
        private DataAccess data = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            studentAnswers = (List<int>)Session["StudentAnswers"];

            try
            {
                dbConn = new SqlConnection(connectionString);

                int studentID = Convert.ToInt16(Session["stdID"]);
                int testID = Convert.ToInt16(Session["TestID"]);

                DataSet memo = data.GetStudentQuestionAnswersForTest(dbConn, studentID, testID);
                grdMemo.DataSource = memo;
                grdMemo.DataBind();
            }
            catch(SqlException ex)
            {

            }
            
        }
    }
}