using Microsoft.AspNetCore.Identity;

namespace Models.Auth
{
    /*With the User class, we extend the IdentityUser class with two additional properties. 
     *These properties will be added to the database as well.
     *We could have used the claims instead of adding the User class
     */
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}