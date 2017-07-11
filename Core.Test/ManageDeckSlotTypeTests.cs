using Core.Model;
using System;
using System.Linq;
using Xunit;

namespace Core.Test
{
    public class ManageDeckSlotTypeTests
    {
        [Fact]
        public void Validate()
        {
            ManageDeckSlotType model = new ManageDeckSlotType() { };

            var errors = model.Validate();
            Assert.Equal(1, errors.Count());

            model.ManageType = Constants.ManageTypes.Add.ToString();
            errors = model.Validate();
            Assert.Equal(0, errors.Count());
        }

    }
}
