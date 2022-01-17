using System.Reflection;

namespace Validation
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
