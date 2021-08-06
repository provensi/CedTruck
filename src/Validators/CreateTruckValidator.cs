using CedTruck.Models;
using FluentValidation;
using System;

namespace CedTruck.Validators
{
    public class CreateTruckValidator : AbstractValidator<Truck>
    {
        public CreateTruckValidator()
        {
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("Model is required");
            RuleFor(x => x.YearFabrication).Must(ValidateYearFabrication).WithMessage("Date must be equal to the current year");
            RuleFor(x => x.YearModel).Must(ValidateYearModel).WithMessage("Date must be equal or higher than the current year");
        }

        public bool ValidateYearFabrication(int YearFabrication)
        {
            var currentYear = DateTime.Now.Year;
            return currentYear.Equals(YearFabrication);
        }

        public bool ValidateYearModel(int YearModel)
        {
            var currentYear = DateTime.Now.Year;
            var nextYear = DateTime.Now.AddYears(1).Year;
            return currentYear.CompareTo(YearModel) <= 0 && nextYear.CompareTo(YearModel) >= 0;
        }
    }
}
