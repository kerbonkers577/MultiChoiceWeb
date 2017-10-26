using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiChoiceWeb
{
    public partial class Memo : System.Web.UI.Page
    {
        List<int> studentAnswers = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            studentAnswers = (List<int>)Session["StudentAnswers"];
        }
    }
}