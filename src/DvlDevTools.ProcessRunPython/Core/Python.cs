using DvlDevTools.Extensions;
using DvlDevTools.ProcessRunPython.Core.PythonElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Core
{
    public class Python
    {
		private readonly List<PythonElement> _pythonElements;

		public Python()
		{
			_pythonElements = new List<PythonElement>();
		}

		public Variable CreateVariable(string name, object value)
		{
			if (name.IsNullOrEmpty())
			{
				throw new ArgumentNullException(name);
			}

			if(value == null)
			{
				throw new ArgumentNullException(value?.ToString());
			}

			return new Variable() { Name = name, Value = value };
		}

		public void AddElement(PythonElement pythonElement)
		{
			if(pythonElement == null)
			{
				throw new ArgumentNullException($"The value of {nameof(pythonElement)} is null. This not permitted", new Exception());
			}

			_pythonElements.Add(pythonElement);
		}

		public void AddRangeOfElements(List<PythonElement> pythonElements)
		{
			if (pythonElements == null)
			{
				throw new ArgumentNullException($"The value of {nameof(pythonElements)} is null. This not permitted", new Exception());
			}

			_pythonElements.AddRange(pythonElements);
		}

		public string BuildScript()
		{
			var stringBuilder = new StringBuilder();

			foreach(var element in _pythonElements)
			{
				stringBuilder.AppendLine(element.ToString());
			}

			return stringBuilder.ToString();
		}

    }
}
