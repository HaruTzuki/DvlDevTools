using DvlDevTools.ProcessRunPython;
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

		public IndexModel(ILogger<IndexModel> logger, PythonRunProcess pythonRunProcess)
		{
			_logger = logger;
			this.pythonRunProcess = pythonRunProcess;
		}

		public async Task OnGet()
		{
			Output = await pythonRunProcess.Invoke("print('Hello World')");
		}
	}
}
