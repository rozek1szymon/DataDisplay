using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1PackagesSender.Models;

namespace Task1PackagesSender.AbstractValidator
{
    public class WrapperValidation : AbstractValidator<MainPackagesIndexData>
    {
        public WrapperValidation()
        {
            RuleFor(package => package.MainPackage.NameOfPackage).NotNull().Equal("\"").Length(3, 50).WithMessage("It is required to write down a Name between 3 and 50 characters");
            RuleFor(package => package.MainPackage.DestinationCityOfDelivery).NotNull().Length(2, 50).WithMessage("Name of City is required and should have 2 to 50 characters");
            RuleForEach(package => package.Deliveries).SetValidator(new DeliveryValidation());
        }
       
    }
}
