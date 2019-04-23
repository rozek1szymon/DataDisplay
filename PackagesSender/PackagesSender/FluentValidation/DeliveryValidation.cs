using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Task1PackagesSender.Models;

namespace Task1PackagesSender.AbstractValidator
{

    /// <summary>
    /// Using Fluent Validation to valid a Delivery
    /// </summary>
    public class DeliveryValidation : AbstractValidator<Delivery>
    {
        public DeliveryValidation()
        {
            RuleFor(delivery => delivery.WeightOfDelivery).NotNull().NotEmpty().WithMessage("It is required to write down a Weight").GreaterThan(0).WithMessage("Weight cannot be 0");
            RuleFor(delivery => delivery.NameOfParcel).NotNull().WithMessage("Name of parcel is required").Length(3, 50).WithMessage("Name of Package should have 3 to 50 characters");
            RuleFor(delivery => delivery.AddressOfDestination).NotNull().WithMessage("Adress of parcel is required").Length(3, 50).WithMessage("Adress of Package should have 3 to 50 characters");
        }
    }
}
