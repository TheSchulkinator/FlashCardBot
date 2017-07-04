using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class InputModel
    {
        public CurrentIntent currentIntent { get; set; }
        public Bot bot { get; set; }

        public class CurrentIntent
        {
            public string Name { get; set; }
            public string ConfirmationStatus { get; set; }
            public Slot slots { get; set; }
        }
        
        public class Slot
        {
            public string PickUpDate { get; set; }
            public string PickUpCity { get; set; }
            public string ReturnDate { get; set; }
            public string CarType { get; set; }
            public string DriverAge { get; set; }
        }

        public class Bot
        {
            public string Alias { get; set; }
            public string Version { get; set; }
            public string Name { get; set; }
        }

        public string UserID { get; set; }

        public string InvocationSource { get; set; }
        public string OutputDialogMode { get; set; }
        public string MessageVersion { get; set; }
        //public string SessionAttributes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Intent Name : {0}", this.currentIntent.Name));
            if (this.currentIntent.slots != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append("Slot Info");
                sb.Append(String.Format("Date : {0}", this.currentIntent.slots.PickUpDate));
            }
            return sb.ToString();
        }
    }
}
