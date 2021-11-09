using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Plugins
{
    public abstract class ScriptPlugin
    {
		protected readonly PythonRunProcessSettings pythonRunProcessSettings;

		protected ScriptPlugin(PythonRunProcessSettings pythonRunProcessSettings)
		{
			this.pythonRunProcessSettings = pythonRunProcessSettings;
		}

        public string FileName { get; set; }
        public abstract string Run();
        public abstract Task<string> RunAsync();
    }
}
