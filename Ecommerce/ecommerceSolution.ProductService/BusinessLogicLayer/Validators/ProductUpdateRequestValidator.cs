using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validators
{
    internal class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
        {
            RuleFor(p => p.ProductID).NotEmpty().WithMessage("Product ID Required");

            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product Name Required");

            RuleFor(p => p.Category).IsInEnum().NotEmpty().WithMessage("Category is Required");

            RuleFor(p => p.UnitPrice).NotEmpty().InclusiveBetween(0, double.MaxValue).WithMessage($"Unit Price is required/ Unit price between 0 to {double.MaxValue}");

            RuleFor(p => p.QuantityInStock).NotEmpty().InclusiveBetween(0, int.MaxValue).WithMessage($"Quantity InStock is required/ Quantity InStock between 0 to {int.MaxValue}");
        }
    }
}
