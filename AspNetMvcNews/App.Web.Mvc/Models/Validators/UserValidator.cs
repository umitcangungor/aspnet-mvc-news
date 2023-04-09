using App.Data;
using Microsoft.AspNetCore.Identity;

namespace App.Web.Mvc.Models.Validators
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();

            if (user.UserName.Length < 5)
            {
                errors.Add(new() { Code = "UserNameLength", Description = "Kullanıcı adı en az 5 karakterden oluşmalıdır." });
            }

            if (user.Email.Substring(0, user.Email.IndexOf("@")) == user.UserName)
            {
                errors.Add(new() { Code = "UserNameContainsEmail", Description = "Kullanıcı adı e-posta ile aynı olamaz!" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
