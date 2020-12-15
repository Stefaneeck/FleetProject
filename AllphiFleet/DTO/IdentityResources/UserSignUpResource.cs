using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.IdentityResources
{
    public class UserSignUpResource
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
