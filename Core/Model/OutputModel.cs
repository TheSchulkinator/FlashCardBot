using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class OutputModel<SlotType> where SlotType : BaseSlotType
    {
        public DialogAction DialogAction { get; set; }
        public string SlotToElict { get; set; }
        public string IntentName { get; set; }
        public SlotType Slots { get; set; }
        public Message Message { get; set; }
        //public string SessionAttributes { get; set; }
    }
}
