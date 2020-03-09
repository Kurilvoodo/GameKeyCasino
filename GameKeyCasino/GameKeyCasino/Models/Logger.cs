using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameKeyCasino
{
    public static class Logger
    {
        private static ILog _log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get
            {
                InitLogger();
                return _log;
            }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}