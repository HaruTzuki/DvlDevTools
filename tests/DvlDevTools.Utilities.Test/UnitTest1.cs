using DvlDevTools.Utilities.Literals;
using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace DvlDevTools.Utilities.Test
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            string text = "ο ήλιος είναι λαμπρός όλη την ημέρα";

            output.WriteLine(text.ToGreeklish(TextCase.ToLowerCase));
            output.WriteLine(text.ToGreeklish(TextCase.ToLowerCase, '-'));
            output.WriteLine(text.ToGreeklish(TextCase.ToUpperCase));
            output.WriteLine(text.ToGreeklish(TextCase.ToSentenceCase));
        }
    }
}
