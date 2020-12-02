using System.Reflection;


namespace WriteServices
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
