using DvlDevTools.ProcessRunPython.Helpers.Enumerations.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Helpers.Enumerations
{
    public enum LogicalOperators
    {
        [OperatorSymbol("and")]
        And,
        [OperatorSymbol("or")]
        Or,
        [OperatorSymbol("not")]
        Not
    }
}
