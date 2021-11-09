using DvlDevTools.ProcessRunPython.Helpers.Enumerations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Helpers.Enumerations
{
    public enum ComparisonOperators
    {
        [OperatorSymbol("==")]
        Equal,
        [OperatorSymbol("!=")]
        NotEqual,
        [OperatorSymbol(">")]
        GreaterThan,
        [OperatorSymbol("<")]
        LessThan,
        [OperatorSymbol(">=")]
        GreaterThanOrEqualTo,
        [OperatorSymbol("<=")]
        LessThanOrEqualTo
    }
}
