using System.Security.Claims;

namespace ToDo.WebApi.Models
{
    public class AuthUser
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public AuthUser(ClaimsPrincipal user)
        {
            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                throw new InvalidOperationException("User is not authorized");
            }
            var claim = user.Claims;
            Id = Convert.ToInt32(claim.First(x => x.Type == ClaimTypes.Sid).Value);
            Name = claim.First(x => x.Type == ClaimTypes.Name).Value;
        }
    }
}
