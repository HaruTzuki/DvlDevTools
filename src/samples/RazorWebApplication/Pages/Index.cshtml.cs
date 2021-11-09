using DvlDevTools.ProcessRunPython;
using DvlDevTools.ProcessRunPython.Core;
using DvlDevTools.ProcessRunPython.Core.PythonElements;
using DvlDevTools.ProcessRunPython.Helpers.Enumerations;
using DvlDevTools.ProcessRunPython.Plugins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApplication.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly PythonRunProcess pythonRunProcess;
		public string Output { get; set; }
		public string Input { get; set; }

		public IndexModel(ILogger<IndexModel> logger, PythonRunProcess pythonRunProcess)
		{
			_logger = logger;
			this.pythonRunProcess = pythonRunProcess;
		}

		public async Task OnGet()
		{
			var python = new Python();

			python.AddElement(new Variable() { Name = "a", Value = 12.2 });
			python.AddElement(new Variable() { Name = "b", Value = "aa" });
			python.AddElement(new Variable() { Name = "c", Value = "12" });
			python.AddElement(new Variable() { Name = "d", Value = 24 });

			var pythonArray = python.CreateVariable("arr", "['apple', 'banana', 'cherry']");
			python.AddElement(pythonArray);

			python.AddElement(new PrintLine() { Value = "b" });

			
			python.AddElement(new PrintLine() { Value = pythonArray.Name });
			python.AddElement(new LoopFor(pythonArray.Name, "x", new PrintLine("x")));

			python.AddElement(new LoopWhile("a", "d", ComparisonOperators.NotEqual, new PythonElement[] {
				new PrintLine("'Hello World'"),
				new PrintLine("'break'")
			}));

			Input = python.BuildScript();

			//Output = pythonRunProcess.Invoke(new HelloWorld());
		}

		public async Task OnPost(string pythonScript)
		{
			Output = await pythonRunProcess.InvokeAsync(pythonScript);
		}
	}
}
