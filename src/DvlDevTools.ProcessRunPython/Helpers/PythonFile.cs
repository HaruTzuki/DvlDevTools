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

		/// <summary>
		/// Create Python File
		/// </summary>
		/// <param name="content">Script written in Python syntax.</param>
		/// <param name="path">Root path that you want to save file.</param>
		/// <param name="autoName">Make true if you want the system create a random file name. If false you must provide the specific file name.</param>
		/// <param name="result">Out variable that fill up with complete file path.</param>
		/// <param name="fileName">If to autoName argument is false you must set up.</param>
		/// <returns></returns>
		public static bool CreatePythonFile(string content, string path, bool autoName, out string result, string fileName = "")
		{

			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(path);
			}

			if(!autoName && string.IsNullOrEmpty(fileName))
			{
				throw new InvalidOperationException($"If {nameof(autoName)} is False then you cannot use {nameof(fileName)} as empty string.");
			}

			fileName = Path.Combine(path, autoName ? $"{Guid.NewGuid():N}.py" : Path.GetExtension(fileName) == ".py" ? fileName : $"{fileName}.py");

			try
			{
				using var fileStream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);
				var contentBytes = Encoding.UTF8.GetBytes(content);
				fileStream.WriteAsync(contentBytes, 0, contentBytes.Length).GetAwaiter().GetResult();
				fileStream.Close();

				result = fileName;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				result = string.Empty;
				return false;
			}

			return true;
		}
	}
}
