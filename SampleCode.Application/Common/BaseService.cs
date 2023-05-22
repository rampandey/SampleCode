using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
//using API.Domain.BatchRunLog;

namespace SampleCode.Common
{
    /// <summary>
    /// Common properties used by the service class's
    /// </summary>
    public class BaseService
    {
        //loggin object
        //protected BatchRunLog CurrentBatchRunLog = null;
        public CultureInfo UKCultureInfo = new CultureInfo("en-GB");
        public CultureInfo USCultureInfo = new CultureInfo("en-US");
        public string serviceName = string.Empty;

        public BaseService()
        {
            //Get the Service name (eg. Airport, Person etc)
            serviceName = this.GetType().Name;
        }
    }
}
