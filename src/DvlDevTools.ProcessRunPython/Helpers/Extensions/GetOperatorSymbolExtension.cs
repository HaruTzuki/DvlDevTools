using DvlDevTools.ProcessRunPython.Helpers.Enumerations.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Helpers.Extensions
{
    internal static class GetOperatorSymbolExtension
    {
        internal static string GetOperatorSymbol<TSource>(this TSource source) 
        {
            var type = source.GetType();

            var name = Enum.GetName(type, source);

            var fieldInfo = type.GetField(name ?? "");

            var attribute = (OperatorSymbolAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(OperatorSymbolAttribute));

            return attribute.OperatorSymbol;
        }
    }
}
