using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DvlDevTools.ProcessRunPython.Services
{
    public static class PythonProcessRunServiceCollectionExtensions
    {
	    public static void AddPythonProcess(this IServiceCollection services,
		    PythonRunProcessSettings settings)
	    {
			// Check if Directory for temp Exist
			if (!Directory.Exists(settings.TempPythonScripts))
				Directory.CreateDirectory(settings.TempPythonScripts);

		    services.AddSingleton(settings);
		    services.AddTransient<PythonRunProcess>();
	    }
    }
}
