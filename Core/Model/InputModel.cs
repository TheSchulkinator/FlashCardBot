using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class InputModel<SlotType> where SlotType : BaseSlotType
    {
        public CurrentIntent<SlotType> CurrentIntent { get; set; }
        public Bot Bot { get; set; }
        public string UserID { get; set; }

        public string InvocationSource { get; set; }
        public string OutputDialogMode { get; set; }
        public string MessageVersion { get; set; }
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

    public class CurrentIntent<SlotType>
    {
        public string Name { get; set; }
        public string ConfirmationStatus { get; set; }
        public SlotType Slots { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(Name), Name));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(ConfirmationStatus), ConfirmationStatus));
            return sb.ToString();
        }
    }

    public class OrderSlotType : BaseSlotType
    {
        public string PickUpDate { get; set; }
        public string PickUpCity { get; set; }
        public string ReturnDate { get; set; }
        public string CarType { get; set; }
        public string DriverAge { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(PickUpDate), PickUpDate));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(PickUpCity), PickUpCity));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(ReturnDate), ReturnDate));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(CarType), CarType));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(DriverAge), DriverAge));
            return sb.ToString();
        }
    }

    public class Bot
    {
        public string Alias { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(Alias), Alias));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(Version), Version));
            sb.Append(String.Format(Constants.STRING_FORMAT_PROPERTY_VALUE, nameof(Name), Name));
            return sb.ToString();
        }
    }
}
