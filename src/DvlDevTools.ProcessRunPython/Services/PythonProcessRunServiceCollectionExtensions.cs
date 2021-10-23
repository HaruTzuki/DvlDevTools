using System;
using System.Collections.Generic;
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
		    Func<IConfiguration, PythonRunProcessSettings> predicate)
	    {
		    services.AddSingleton(predicate);
		    services.AddScoped<PythonRunProcess>();
	    }
    }
}
