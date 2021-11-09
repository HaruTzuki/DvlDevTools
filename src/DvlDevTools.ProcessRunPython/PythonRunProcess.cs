using DvlDevTools.ProcessRunPython.Helpers;
using DvlDevTools.ProcessRunPython.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython
{
    public class PythonRunProcess
    {
	    private readonly PythonRunProcessSettings _pythonRunProcessSettings;
		private readonly StringBuilder _outputContent;
		private bool isCreatedFile = false;

	    public PythonRunProcess(PythonRunProcessSettings pythonRunProcessSettings)
	    {
		    _pythonRunProcessSettings = pythonRunProcessSettings;
			_outputContent = new StringBuilder();
	    }

		public string Invoke(string script)
		{
			string fileName;

			if(Path.GetExtension(script) != ".py")
			{
				PythonFile.CreatePythonFile(script, _pythonRunProcessSettings.TempPythonScripts, out fileName);
				isCreatedFile = true;
			}
			else
			{
				fileName = script;
			}

			var startInfo = new ProcessStartInfo();
			startInfo.FileName = _pythonRunProcessSettings.PythonPath;
			startInfo.RedirectStandardOutput = true;
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = false;
			startInfo.Arguments = fileName;
			using var pythonProcess = new Process();
			pythonProcess.OutputDataReceived += (sender, args) =>
			{
				if (args != null && !string.IsNullOrEmpty(args.Data))
				{
					_outputContent.AppendLine(args.Data);
				}
			};

			pythonProcess.StartInfo = startInfo;
			pythonProcess.Start();
			pythonProcess.BeginOutputReadLine();
			pythonProcess.WaitForExit();
			pythonProcess.Close();

			if (isCreatedFile)
			{
				PythonFile.DeletePythonFile(fileName);
			}

			return _outputContent.ToString();
		}

		public string Invoke(ScriptPlugin scriptPlugin)
		{
			var startInfo = new ProcessStartInfo();
			startInfo.FileName = _pythonRunProcessSettings.PythonPath;
			startInfo.RedirectStandardOutput = true;
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = false;
			startInfo.Arguments = scriptPlugin.Run();
			using var pythonProcess = new Process();
			pythonProcess.OutputDataReceived += (sender, args) =>
			{
				if (args != null && !string.IsNullOrEmpty(args.Data))
				{
					_outputContent.AppendLine(args.Data);
				}
			};

			pythonProcess.StartInfo = startInfo;
			pythonProcess.Start();
			pythonProcess.BeginOutputReadLine();
			pythonProcess.WaitForExit();
			pythonProcess.Close();

			return _outputContent.ToString();
		}

		public async Task<string> InvokeAsync(string script)
	    {
			return await Task.Run<string>(() =>
			{
				string fileName;
				// Save to file
				if (Path.GetExtension(script) != ".py")
				{
					PythonFile.CreatePythonFile(script, _pythonRunProcessSettings.TempPythonScripts, out fileName);
					isCreatedFile = true;
				}
				else
				{
					fileName = script;
				}


				var startInfo = new ProcessStartInfo();
				startInfo.FileName = _pythonRunProcessSettings.PythonPath;
				startInfo.RedirectStandardOutput = true;
				startInfo.CreateNoWindow = true;
				startInfo.UseShellExecute = false;
				startInfo.Arguments = fileName;
				using var pythonProcess = new Process();
				pythonProcess.OutputDataReceived += (sender, args) =>
				{
					if (args != null && !string.IsNullOrEmpty(args.Data))
					{
						_outputContent.AppendLine(args.Data);
					}
				};

				pythonProcess.StartInfo = startInfo;
				pythonProcess.Start();
				pythonProcess.BeginOutputReadLine();
				pythonProcess.WaitForExit();
				pythonProcess.Close();

				if (isCreatedFile)
				{
					PythonFile.DeletePythonFile(fileName);
				}

				return _outputContent.ToString();
			});
	    }

		public async Task<string> InvokeAsync(ScriptPlugin scriptPlugin)
		{
			return await Task.Run<string>(async () =>
			{
				var startInfo = new ProcessStartInfo();
				startInfo.FileName = _pythonRunProcessSettings.PythonPath;
				startInfo.RedirectStandardOutput = true;
				startInfo.CreateNoWindow = true;
				startInfo.UseShellExecute = false;
				startInfo.Arguments = await scriptPlugin.RunAsync();
				using var pythonProcess = new Process();
				pythonProcess.OutputDataReceived += (sender, args) =>
				{
					if (args != null && !string.IsNullOrEmpty(args.Data))
					{
						_outputContent.AppendLine(args.Data);
					}
				};

				pythonProcess.StartInfo = startInfo;
				pythonProcess.Start();
				pythonProcess.BeginOutputReadLine();
				pythonProcess.WaitForExit();
				pythonProcess.Close();

				return _outputContent.ToString();
			});
		}
    }
}
