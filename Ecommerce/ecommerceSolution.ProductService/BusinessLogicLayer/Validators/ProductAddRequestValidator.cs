using BusinessLogicLayer.DTO;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validators
{
    internal class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
       public ProductAddRequestValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product Name is required");

            RuleFor(p => p.Category).IsInEnum().NotEmpty().WithMessage("Please select Category");

            RuleFor(p => p.UnitPrice).NotEmpty().InclusiveBetween(0,double.MaxValue).WithMessage($"Unit Price Required/Unit price should between 0 to {double.Max}");

            RuleFor(p => p.QuantityInStock).NotEmpty().InclusiveBetween(0, int.MaxValue).WithMessage($"Quantity in stock is required/Quantity In stock between 0 to {int.MaxValue}");
        }
    }
}
