using CedTruck.Models;
using CedTruck.Validators;
using FluentValidation.TestHelper;
using Xunit;
using System;

namespace TestCedTruck
{
    public class CreateTruckValidatorUnitTest
    {
        [Fact]
        public void ShouldHaveErrorWhenTruckModelIsEmpty()
        {
            var truck = new Truck { ModelId = 0L };

            var validator = new CreateTruckValidator();
            var result = validator.TestValidate(truck);

            result.ShouldHaveValidationErrorFor(x => x.ModelId);
        }

        [Fact]
        public void ShouldHaveErrorWhenYearFabricationIsNotThisYear()
        {
            var nextYear = DateTime.Now.AddYears(1).Year;
            var truck = new Truck { YearFabrication = nextYear };

            var validator = new CreateTruckValidator();
            var result = validator.TestValidate(truck);

            result.ShouldHaveValidationErrorFor(x => x.YearFabrication);
        }

        [Fact]
        public void ShouldHaveErrorWhenYearModelIsNotThisYearOrNextYear()
        {
            var nextTwoYears = DateTime.Now.AddYears(2).Year;
            var truck = new Truck { YearModel = nextTwoYears };

            var validator = new CreateTruckValidator();
            var result = validator.TestValidate(truck);

            result.ShouldHaveValidationErrorFor(x => x.YearModel);
        }

    }
}
