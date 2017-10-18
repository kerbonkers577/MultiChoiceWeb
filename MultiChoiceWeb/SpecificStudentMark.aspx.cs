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
    public partial class SpecificStudentMark : System.Web.UI.Page
    {
        private string connectionString = Properties.Settings.Default.ConnectionString;
        private DataAccess data = new DataAccess();
        private SqlConnection dbConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbConn = new SqlConnection(connectionString);
            DataSet studentsMarks = data.GetStudentMark(dbConn, Session["studentNum"].ToString());
            grdMarks.DataSource = studentsMarks;
            grdMarks.DataBind();

            //grdMarks.Columns[1].HeaderText = "Student's Name";
            //grdMarks.Columns[2].HeaderText = "Test";
            //grdMarks.Columns[3].HeaderText = "Mark for test";

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }
    }
}