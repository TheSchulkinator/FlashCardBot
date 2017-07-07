using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class OutputModel<SlotType> where SlotType : ISlotType
    {
        public DialogAction<SlotType> dialogAction { get; set; }
       
        public SessionAttributes sessionAttributes{ get; set; }
    }
}
