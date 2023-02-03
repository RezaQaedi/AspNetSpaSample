using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspCoreSpaSample.Endpoints
{
    public class RegisterEndpoint
    {
        public class RegisterForm
        {
            [Required]
            public string? UserName { get; set; }

            [Required, Compare(nameof(ConfirmPassword))]
            public string? Password { get; set; }

            [Required]
            public string? ConfirmPassword { get; set; }
        }

        public static async Task<IResult> Handler([FromBody] RegisterForm form, 
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser() { UserName = form.UserName };
            var createUserResult = await userManager.CreateAsync(user, form.Password!);

            if (!createUserResult.Succeeded)
            {
                return Results.BadRequest();
            }

            await signInManager.SignInAsync(user, true);

            // send email conformation
            // ... 

            return Results.Ok();
        }
    }
}
