using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

internal interface ILogger
{
    void Log();
}

public class DatabaseLogger : ILogger
{

    public void Log()
    {
        Console.WriteLine("you are successfully Loged in Data base");
    }
}
public class FileLogger : ILogger
{

    public void Log()
    {
        Console.WriteLine("you are successfully Loged in File");
    }
}
public class CloudLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine(" you are successfully Loged in Cloud");
    }
}
class main
{
    public static void Main()
    {
        main ma = new main();
        ILogger Logs;
        Console.WriteLine("Enter the Log Type (Database, File ,Cloud);");
        string LogType = Console.ReadLine();
        Logs = ma.getLogger(LogType);
        Logs.Log();
       
    }
    public ILogger getLogger(string type)
    {
        ILogger Logs;
        if(type == "Database")
        {
            Logs = new DatabaseLogger();
        }
        else if(type == "File")
        {
            Logs = new FileLogger();
        }
        else
        {
            Console.WriteLine("The log type is not exist");
            return null;
        }
        return Logs;
    }
}



