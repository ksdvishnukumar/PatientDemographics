using Logger;
using System;
using System.Diagnostics;

namespace PatientDemographicsUI
{
    public partial class EditPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Disabling the control if the type of page mode is View
                if (Request.QueryString["type"] == "V")
                {
                    btnUpdate.Visible = false;
                    forename.Disabled = true;
                    surname.Disabled = true;
                    dob.Disabled = true;
                    gender.Disabled = true;
                    homenumber.Disabled = true;
                    worknumber.Disabled = true;
                    phonenumber.Disabled = true;
                    titleText.InnerText = "View Person";
                }
                else
                {
                    titleText.InnerText = "Edit Person";
                }
                hdnPID.Value = Convert.ToString(Request.QueryString["PID"]);
            }
            catch (Exception ex)
            {
                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
            }
        }
    }
}