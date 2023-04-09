using Microsoft.AspNetCore.Identity;

namespace App.Web.Mvc.Models.Validators
{
    public class ErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName) => new() { Code = "InvalidUserName", Description = $"\"{userName}\" kullanıcı adı geçersiz." };

        public override IdentityError DuplicateEmail(string email) => new() { Code = "DuplicateEmail", Description = $"\"{email}\" adresi kullanımdadır." };

        public override IdentityError PasswordTooShort(int length) => new() { Code = "PasswordTooShort", Description = $"Şifre en az {length} karakter olmalıdır." };

        public override IdentityError PasswordRequiresUpper() => new() { Code = "PasswordRequiresUpper", Description = "Şifre büyük harf içermelidir." };
    }
}
