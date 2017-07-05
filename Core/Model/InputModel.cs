using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class InputModel<SlotType> where SlotType : BaseSlotType
    {
        public string MessageVersion { get; set; }
        public string InvocationSource { get; set; }
        public string UserID { get; set; }
        public Bot Bot { get; set; }
        public string OutputDialogMode { get; set; }
        public CurrentIntent<SlotType> CurrentIntent { get; set; }
        //public string SessionAttributes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentIntent != null)
            {
                sb.Append(CurrentIntent.ToString());
                if (this.CurrentIntent.Slots != null)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(this.CurrentIntent.Slots.ToString());
                }
            }
            if (this.Bot != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(this.Bot.ToString());
            }
            return sb.ToString();
        }
    }
}
