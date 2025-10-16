

using Microsoft.Extensions.Logging;
namespace CollegeApp.Mylogger
{
    public class LogtoDb : IMylogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoDb");
        }
    }
}



