using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ResponseBuilder
    {
        public static OutputModel<T> BuildResponse<T>(OutputModel<T> outputModel = null) where T : ISlotType
        {
            if (outputModel == null)
                outputModel = new OutputModel<T>();



            return outputModel;
        }
    }
}
