using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Core.DTO
{
    public record AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success
    )
    {
        // Parameter less Constructor
        public AuthenticationResponse() : this(default,default,default,default,default, default)
        {

        }
    }
   
}
