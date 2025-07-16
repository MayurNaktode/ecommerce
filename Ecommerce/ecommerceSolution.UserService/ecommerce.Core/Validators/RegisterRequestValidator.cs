using ecommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Id is required").EmailAddress().WithMessage("Email Id is invalid");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(x => x.PersonName).NotEmpty().WithMessage("PersonName is required").Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

            RuleFor(x => x.Gender).IsInEnum().WithMessage("Gender is required");
        }
    }
}
