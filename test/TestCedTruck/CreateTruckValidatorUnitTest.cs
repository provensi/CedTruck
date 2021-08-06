using CedTruck.Models;
using CedTruck.Validator;
using FluentValidation.TestHelper;
using Xunit;

namespace TestCedTruck
{
    public class CreateTruckValidatorUnitTest
    {
        [Fact]
        public void ShouldHaveErrorWhenEmptyTruckModel()
        {
            var truck = new Truck { ModelId = 0L };

            var validator = new CreateTruckValidator();
            var result = validator.TestValidate(truck);

            result.ShouldHaveValidationErrorFor(x => x.ModelId);
        }
    }
}
