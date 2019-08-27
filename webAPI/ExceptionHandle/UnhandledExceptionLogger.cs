using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace webAPI.ExceptionHandle
{
    public class UnhandledExceptionLogger: ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            Console.WriteLine(log);
            Console.ReadLine();
        }
    }
}