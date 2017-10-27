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
        private string connectionString = 
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();
        private DataAccess data = new DataAccess();
        private SqlConnection dbConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbConn = new SqlConnection(connectionString);
            DataSet studentsMarks = data.GetStudentMark(dbConn, Session["studentNum"].ToString());
            grdMarks.DataSource = studentsMarks;
            grdMarks.DataBind();

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }
    }
}