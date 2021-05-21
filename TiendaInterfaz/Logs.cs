using System.Runtime.CompilerServices;
using log4net;

namespace TiendaInterfaz
{
    class Logs
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }
    }
}
