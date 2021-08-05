using CedTruck.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedTruck.Validator
{
    public class CreateTruckValidator : AbstractValidator<Truck>
    {
        public CreateTruckValidator()
        {
            //RuleFor(x => x.Model).NotNull().WithMessage("Model is required");
            RuleFor(x => x.YearFabrication).Must(IsOnDate).WithMessage("Date has to be more then now");
            RuleFor(x => x.YearModel).Must(IsOnDate).WithMessage("Date has to be more then now");
        }

        public bool IsOnDate(DateTime date)
        {
            var result = DateTime.Compare(date, DateTime.Now);
            if (result >= 0)
            {
                return true;
            }
            else 
                return false;
        }
    }
}
