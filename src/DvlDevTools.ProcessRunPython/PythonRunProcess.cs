using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython
{
    public class PythonRunProcess
    {
	    private readonly PythonRunProcessSettings _pythonRunProcessSettings;

	    public PythonRunProcess(PythonRunProcessSettings pythonRunProcessSettings)
	    {
		    _pythonRunProcessSettings = pythonRunProcessSettings;
	    }

	    public async Task Invoke(string script)
	    {
		    var startInfo = new ProcessStartInfo();
		    startInfo.FileName = _pythonRunProcessSettings.PythonPath;
		    startInfo.RedirectStandardOutput = true;
		    startInfo.CreateNoWindow = true;
		    startInfo.UseShellExecute = false;
		    startInfo.Arguments = script;

		    using var pythonProcess = Process.Start(startInfo);
		    pythonProcess.OutputDataReceived += (sender, args) =>
		    {
			    Debug.WriteLine(args.Data);
		    };
	    }
    }
}
