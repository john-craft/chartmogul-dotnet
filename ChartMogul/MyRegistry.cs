using StructureMap;

namespace ChartMogul.API
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
