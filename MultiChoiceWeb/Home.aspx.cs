using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiChoiceWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void studentBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
            
        }

        protected void teacherBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPage.aspx");
        }

        protected void btnMasterPages_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataMasterPage.aspx");
        }
    }
}