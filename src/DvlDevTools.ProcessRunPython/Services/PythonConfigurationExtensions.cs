using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DvlDevTools.ProcessRunPython.Services
{
    public static class PythonConfigurationExtensions
    {
	    public static PythonRunProcessSettings GetPythonSettings(this IConfiguration configuration)
	    {
		    return configuration.GetSection("PythonSettings") as PythonRunProcessSettings;
	    }
    }
}
