﻿using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using NLog;
using Newtonsoft.Json;

namespace ChatBotHook.Parse
{
    public class InputDeserializer : ILambdaSerializer
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public T Deserialize<T>(Stream requestStream)
        {
            _logger.Info(String.Format("Starting De-Serialize of Type {0}", typeof(T).FullName));
            try
            {
                StringBuilder sb = new StringBuilder();
                using (var sr = new StreamReader(requestStream))
                {

                    sb.Append(sr.ReadToEnd());
                    _logger.Info(String.Format("ReadStream: {0}", sb.ToString()));
                    return JsonConvert.DeserializeObject<T>(sb.ToString());
                }
            }
            catch (Exception e)
            {
                _logger.Error(String.Format("Exception : {0}{1}{2}", e.Message, Environment.NewLine, e.StackTrace));
            }
            _logger.Info("Returning Default");
            return default(T);
        }

        public void Serialize<T>(T response, Stream responseStream)
        {
            _logger.Info(String.Format("Starting Serialize of Type {0}", typeof(T).FullName));
            string json = JsonConvert.SerializeObject(response);
            var sw = new StreamWriter(responseStream);
            sw.Write(json);
            sw.Flush();
        }

        private const string ResponseFormat = "{ \"dialogAction\": { \"type\": \"Close\", \"fulfillmentState\": \"fulfilled\", \"message\": { \"contentType\": \"PlainText\", \"content\": {0} } } }";

        private string BuildResponse(string message)
        {
            return String.Format(ResponseFormat, message);
        }
    }
}
