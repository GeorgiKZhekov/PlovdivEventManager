namespace PlovdivEventManager.Infrastructure
{
    using System.Security.Claims;
    public static class ClaimsPrincipalExtension
    {
        public static string GetId(this ClaimsPrincipal user) 
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
