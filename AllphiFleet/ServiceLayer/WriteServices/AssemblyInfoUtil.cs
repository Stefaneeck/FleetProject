using System.Reflection;

namespace WriteServices
{
    //class to retrieve assembly
    public static class AssemblyInfoUtil
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
