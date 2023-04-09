using App.Data;
using Microsoft.AspNetCore.Identity;

namespace App.Web.Mvc.Models.Validators
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errors = new List<IdentityError>();

            if (user.UserName == password)
            {
                errors.Add(new() { Code = "PasswordContainsUsername", Description = "Şifre kullanıcı adını içeremez." });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
