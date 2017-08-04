using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using BlueprintBaseName;

namespace BlueprintBaseName.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestPigLatinFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var latin = function.FunctionHandler("I Love Pig Latin", context);
            Assert.Equal("iyay ovelay igpay atinlay", latin);
        }
    }
}
