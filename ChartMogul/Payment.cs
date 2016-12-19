
namespace OConnors.ChartMogul.API
{
    public class Payment : AbstractTransaction
    {
        public new string Type
        { get { return "payment"; } }
    }
}
