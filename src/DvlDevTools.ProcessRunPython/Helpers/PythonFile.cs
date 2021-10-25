using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Helpers
{
    public static class PythonFile
    {
        internal static bool CreatePythonFile(string script, string path, out string fileName)
		{
			if (string.IsNullOrEmpty(script))
			{
				throw new ArgumentNullException(script);
			}

			try
			{
				fileName = Path.Combine(path, $"{Guid.NewGuid()}.py");
				using var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
				var content = Encoding.UTF8.GetBytes(script);
				fileStream.WriteAsync(content, 0, content.Length).GetAwaiter().GetResult();
				fileStream.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				fileName = "";
				return false;
			}

			return true;
		}

		internal static bool DeletePythonFile(string fileName)
		{
			try
			{
				File.Delete(fileName);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}

			return true;
		}
	}
}
