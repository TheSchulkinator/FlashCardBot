using Core.Model;
using Newtonsoft.Json;
using System;
using Xunit;

namespace ChatBotHook.IntentHandlers.Test
{
    public class IntentHandlerTests
    {
        [Fact]
        public void Test_ManageDeckHandler()
        {
            InputModel<ManageDeckSlotType> inputModel = new InputModel<ManageDeckSlotType>();
            inputModel.CurrentIntent.Name = "ManageDecks";
            string json = JsonConvert.SerializeObject(inputModel);

            ManageDeckHandler manageDeckHandler = new ManageDeckHandler();

            string output = manageDeckHandler.HandleIntent(JsonConvert.DeserializeObject<dynamic>(json));
        }
    }
}
