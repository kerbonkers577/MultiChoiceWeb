using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiChoiceWeb
{
    public partial class TeacherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMakeTest_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewAllMarks_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllStudentsMarks.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}