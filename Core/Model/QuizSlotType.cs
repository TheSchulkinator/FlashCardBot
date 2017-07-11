using System;
using System.Collections.Generic;
using System.Text;
using Core.ComponentModel;

namespace Core.Model
{
    public class QuizSlotType : ISlotType
    {
        public string Date { get; set; }

        public string GetSlotToElicit()
        {
            return nameof(Date);
        }

        public IEnumerable<ValidationError> Validate()
        {
            throw new NotImplementedException();
        }
    }
}
