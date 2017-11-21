using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPTravelsTest.Utils
{
    public class Logger
    {
        private static log4net.ILog instance;
        private Logger()
        {

        }

        public static log4net.ILog GetLoggerInstance()
        {
            if (instance == null)
            {
                return instance = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
            else return instance;
        }
    }
}
