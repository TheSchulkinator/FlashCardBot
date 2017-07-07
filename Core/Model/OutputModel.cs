using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class OutputModel<SlotType> where SlotType : ISlotType
    {
        public DialogAction<SlotType> DialogAction { get; set; }
       
        //public string SessionAttributes { get; set; }
    }
}
