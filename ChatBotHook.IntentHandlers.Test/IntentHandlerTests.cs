using ChatBotHook.IntentHandlers.Test.Mock;
using Core;
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
            inputModel.UserID = "useid";
            inputModel.CurrentIntent.Name = "ManageDecks";
            inputModel.CurrentIntent.Slots = new ManageDeckSlotType();
            inputModel.CurrentIntent.Slots.ManageType = Constants.ManageTypes.Add.ToString();
            string json = JsonConvert.SerializeObject(inputModel);

            MockDAL mockDal = new MockDAL();
            ManageDeckHandler manageDeckHandler = new ManageDeckHandler(mockDal);

            string output = manageDeckHandler.HandleIntent(JsonConvert.DeserializeObject<dynamic>(json));
            OutputModel<ManageDeckSlotType> outputModel= JsonConvert.DeserializeObject<OutputModel<ManageDeckSlotType>>(output);

            Assert.NotNull(outputModel);
            Assert.Equal(nameof(ManageDeckSlotType.DeckName), outputModel.dialogAction.slotToElicit);
            Assert.NotNull(outputModel.dialogAction.slots);
            Assert.Equal(Constants.ManageTypes.Add.ToString(), outputModel.dialogAction.slots.ManageType);

            inputModel.CurrentIntent.Slots.DeckName = "DeckName";
            json = JsonConvert.SerializeObject(inputModel);
            output = manageDeckHandler.HandleIntent(JsonConvert.DeserializeObject<dynamic>(json));
            outputModel = JsonConvert.DeserializeObject<OutputModel<ManageDeckSlotType>>(output);

            Assert.True(mockDal.AddDeckCalled);
            Assert.False(mockDal.GetDeckCalled);
            Assert.False(mockDal.UpdateDeckCalled);
            Assert.Equal("useid", mockDal.LastDataPassed.UserId);
            Assert.Equal("DeckName", mockDal.LastDataPassed.DeckName);
        }
    }
}
