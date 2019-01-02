using System.Configuration;

namespace PatientDemographicsUI
{
    public class Configuration
    {
        public static string WebApiBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WEBAPIBASEURL"];
            }
        }
    }
}