using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Threading.Tasks;

namespace AuthApi
{
    public class CustomProfileService : IProfileService
    {
        #region commentGetProfileDataAsync
        /*
         * we create a logic to include required claims for a user using the context object. 
         * There, we fetch the SubjectId and use it to find a user from our InMemoryConfig class. 
         * Lastly, we just add claims to the context object
         */
        #endregion
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = InMemoryConfig.GetUsers()
                .Find(u => u.SubjectId.Equals(sub));

            context.IssuedClaims.AddRange(user.Claims);
            return Task.CompletedTask;
        }

        #region commentIsActiveAsync
        /*
         * We determine if a user is currently allowed to obtain tokens. 
         * So, if we find a user based on the SubjectId, we return true, otherwise false.
         */
        #endregion
        public Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = InMemoryConfig.GetUsers()
                .Find(u => u.SubjectId.Equals(sub));

            context.IsActive = user != null;
            return Task.CompletedTask;
        }
    }
}
