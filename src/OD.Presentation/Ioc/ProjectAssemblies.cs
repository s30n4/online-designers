using System.Reflection;

namespace OD.Presentation.Ioc
{
    public static class ProjectAssemblies
    {
        public static Assembly ServiceLayer => Assembly.Load(new AssemblyName("OD.Application"));
    }
}
