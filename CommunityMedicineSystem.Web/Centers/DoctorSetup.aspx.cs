using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.Web.Centers
{
    public partial class DoctorSetup : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"].ToString() == "user")
                    Response.Redirect("../Login/Login.aspx");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
        }
    }
}