using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Biblioteca.Forms
{
    static class Program
    {
        private static HttpRuntime _httpRuntime;

        public static Cache Cache
        {
            get
            {
                EnsureHttpRuntime();
                return HttpRuntime.Cache;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInicio());
        }

        private static void EnsureHttpRuntime()
        {
            if (null == _httpRuntime)
            {
                try
                {
                    Monitor.Enter(typeof(Program));
                    if (null == _httpRuntime)
                    {
                        // Create an Http Content to give us access to the cache.
                        _httpRuntime = new HttpRuntime();
                    }
                }
                finally
                {
                    Monitor.Exit(typeof(Program));
                }
            }
        }

    }
}
