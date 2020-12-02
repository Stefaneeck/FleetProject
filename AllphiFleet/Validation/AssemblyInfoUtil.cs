using System.Reflection;


namespace Validation
{
    //Klasse om assembly op te halen (voor automapper configuratie)
    public static class AssemblyInfoUtil
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
