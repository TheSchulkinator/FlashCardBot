using Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotHook.IntentHandlers
{
    public class AddOrRecognizeHandler : IIntentHandler<OrderIntentSlotType>
    {
        public InputModel<OrderIntentSlotType> InputModel { get; set; }
        //private IMapperService _mapperService = new MapperService();
        public dynamic HandleIntent(dynamic inputModel)
        {
            var model = JsonConvert.DeserializeObject<InputModel<OrderIntentSlotType>>(inputModel.ToString());
            return null;
        }
    }
}
