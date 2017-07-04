using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using ChatBotHook;
using ChatBotHook.Parse;
using Core.Model;
using System.IO;

namespace ChatBotHook.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            //var upperCase = function.FunctionHandler("hello world", context);

            //Assert.Equal("HELLO WORLD", upperCase);
        }

        [Fact]
        public void TestDeserialize()
        {
            string input = "{\"currentIntent\": { \"slots\": { \"PickUpDate\": \"2030-11-08\", \"PickUpCity\": \"Chicago\", \"ReturnDate\": \"2030-11-08\", \"CarType\": \"economy\", \"DriverAge\": 21 },\"name\": \"BookCar\",\"confirmationStatus\": \"None\"},\"bot\": {\"alias\": \"$LATEST\",\"version\": \"$LATEST\",\"name\": \"BookTrip\"},\"userId\": \"John\",\"invocationSource\": \"DialogCodeHook\",\"outputDialogMode\": \"Text\",\"messageVersion\": \"1.0\",\"sessionAttributes\": { }}";
            InputDeserializer d = new InputDeserializer();
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.Write(input);
                    sw.Flush();
                    var l = ms.Length;
                    ms.Position = 0;
                    var returnModel = d.Deserialize<InputModel>(ms);

                    Assert.NotNull(returnModel);
                    Assert.IsType(typeof(InputModel), returnModel);
                    Assert.NotNull(returnModel.currentIntent);
                    Assert.NotNull(returnModel.currentIntent.slots);
                }
            }
        }
    }
}
