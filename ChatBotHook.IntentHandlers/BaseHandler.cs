using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Newtonsoft.Json;

namespace ChatBotHook.IntentHandlers
{
    public abstract class BaseHandler<T> : IIntentHandler<T> where T : ISlotType
    {
        public InputModel<T> InputModel { get; set; }

        public string HandleIntent(dynamic inputModel)
        {
            InputModel = JsonConvert.DeserializeObject<InputModel<T>>(inputModel.ToString());
            return SerializeOutput(HandleIntent());
        }

        private string SerializeOutput(OutputModel<T> outputModel)
        {
            return JsonConvert.SerializeObject(outputModel);
        }

        public abstract OutputModel<T> HandleIntent();
    }
}
