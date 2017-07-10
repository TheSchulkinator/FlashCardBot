using System;
using System.Collections.Generic;
using System.Text;
using Core.ComponentModel;

namespace Core.Model
{
    public class OrderIntentSlotType : ISlotType
    {
        public string PickUpDate { get; set; }
        public string PickUpCity { get; set; }
        public string ReturnDate { get; set; }
        public string CarType { get; set; }
        public string DriverAge { get; set; }

        public string GetSlotToElicit()
        {
            throw new NotImplementedException();
        }

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

        public IEnumerable<ValidationError> Validate()
        {
            throw new NotImplementedException();
        }
    }
}
