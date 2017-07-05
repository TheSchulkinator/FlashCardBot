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
        string input = "{\"currentIntent\": { \"slots\": { \"PickUpDate\": \"2030-11-08\", \"PickUpCity\": \"Chicago\", \"ReturnDate\": \"2030-11-08\", \"CarType\": \"economy\", \"DriverAge\": 21 },\"name\": \"BookCar\",\"confirmationStatus\": \"None\"},\"bot\": {\"alias\": \"$LATEST\",\"version\": \"$LATEST\",\"name\": \"BookTrip\"},\"userId\": \"John\",\"invocationSource\": \"DialogCodeHook\",\"outputDialogMode\": \"Text\",\"messageVersion\": \"1.0\",\"sessionAttributes\": { }}";

        [Fact]
        public void TestDeserialize()
        {
            var returnModel = CreateTestModel<OrderIntentSlotType>();
            Assert.NotNull(returnModel);
            Assert.IsType(typeof(InputModel<OrderIntentSlotType>), returnModel);
            Assert.NotNull(returnModel.CurrentIntent);
            Assert.NotNull(returnModel.CurrentIntent.Slots);
            Assert.NotNull(returnModel.Bot);
        }

        [Fact]
        public void TestSerialize()
        {
            string filePath = @"C:\testFolder\test.txt";
            InputModel<OrderIntentSlotType> inputModel = CreateTestModel<OrderIntentSlotType>();
            MemoryStream outputStream = new MemoryStream();
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                new InputDeserializer().Serialize<InputModel<OrderIntentSlotType>>(inputModel, fs);
            }
            Assert.True(File.Exists(filePath));
            DeleteFile(filePath);
        }

        private InputModel<T> CreateTestModel<T>() where T : BaseSlotType
        {
            InputDeserializer d = new InputDeserializer();
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.Write(input);
                    sw.Flush();
                    var l = ms.Length;
                    ms.Position = 0;
                    return d.Deserialize<InputModel<T>>(ms);
                }
            }
        }

        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
