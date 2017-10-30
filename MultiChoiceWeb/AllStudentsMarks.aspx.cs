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
    public partial class AllStudentsMarks : System.Web.UI.Page
    {
        private string connectionString = 
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["database"].ToString();
        private SqlConnection dbConn;
        private DataAccess data = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dbConn = new SqlConnection(connectionString);
                DataSet marks = data.GetStudentMarkTable(dbConn);
                grdMarks.DataSource = marks;
                grdMarks.DataBind(); 
            }
            catch(SqlException ex)
            {
                Session["Error"] = "The following error occurred : \n" + ex.Message.ToString() + " : " + ex.ToString();
            }
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPage.aspx");
        }
    }
}