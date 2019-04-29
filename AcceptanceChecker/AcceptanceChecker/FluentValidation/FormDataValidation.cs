using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1PackagesSender.Models;

namespace Task1PackagesSender.FluentValidation
{
    public class FormDataValidation : AbstractValidator<FormData>
    {
        public FormDataValidation()
        {
            RuleFor(ask => ask.Category).NotEmpty();
            RuleFor(ask => ask.TotalValue).GreaterThan(0).WithMessage("You have to write some limit").LessThan(1000000).WithMessage("Too much");
        }
    }
}
