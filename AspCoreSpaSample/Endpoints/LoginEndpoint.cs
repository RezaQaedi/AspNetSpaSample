using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSpaSample.Endpoints
{
    public class LoginEndpoint
    {
        public static async Task<IResult> Handler([FromBody] LoginForm form, SignInManager<IdentityUser> signInManager)
        {
            var result = await signInManager.PasswordSignInAsync(form.UserName!, form.Passoword!, true, false);

            if (result.Succeeded)
            {
                return Results.Ok();
            }

            return Results.BadRequest();
        }
    }
}
