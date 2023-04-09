using App.Data;
using App.Data.Abstract;
using App.Web.Mvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ISendGridEmail _sendGridEmail;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, ISendGridEmail sendGridEmail)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _sendGridEmail = sendGridEmail;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.ReturnUrl = returnUrl ?? Url.Content("~/");
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email); // Kullanıcıyı bulamadığı için giriş yapamıyormuş!!!!
                if (user != null)
                {
                    await _signInManager.SignOutAsync(); // Kullanıcı bulunması durumunda önceki oturumdan kalma olası cookie bilgilerini temizlemek için 

                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user); // Giriş işleminin başarılı olmasıyla, giriş işlemi başarılı olana değin yapılan hatalı girişleri sıfırlar.

                        await _userManager.SetLockoutEndDateAsync(user, null); // Hesap, önceki başarısız giriş denemeleriyle kilitlenmişse bu metot ile sıfırlıyoruz.
                    }
                    if (result.IsLockedOut)
                    {
                        var lockoutEnd = await _userManager.GetLockoutEndDateAsync(user); // hesabın kilitli kalacağı zamanı elde ediyor.

                        var timeLeft = lockoutEnd.Value - DateTime.Now; // Bu ise kilitlendikten sonra açılmasına kaç dk kaldığını gösteriyor.

                        ModelState.AddModelError(string.Empty, $"Bu hesap geçici olarak askıya alınmıştır, lütfen {timeLeft.Minutes} dakika sonra tekrar deneyin.");

                        return View("Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Geçersiz şifre veya e-posta!");
                        return View(loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı!");
                }
            }
            return View(loginViewModel);
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email); // Bu metod unique email istiyor!!!! model.Email.FirstOrDefault().ToString() şeklinde yazınca da çalışıyor ancak 2 tane aynı email'e farklı kayıtlı kullanıcı olduğu için mail'i gönderemiyor!!!
                if (user == null)
                {
                    return RedirectToAction("ForgotPasswordConfirmation");
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user); // şifre sıfırlanması için bir token üretiliyor ve kullanıcıya özel.
                var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme); // kullanıcıya gönderilecek olan özel token için link oluşturuluyor.

                await _sendGridEmail.SendEmailAsync(model.Email, "Şifre Sıfırlama Onayı", "Bu linke tıklayarak şifrenizi sıfırlayabilirsiniz: " + "<a href=\"" + callbackurl + "\">Link</a>");
                return RedirectToAction("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string? code = null)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "Kullanıcı Bulunamadı!");
                    return View();
                }
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
            }
            return View(resetPasswordViewModel);
        }
        [HttpGet]
        public IActionResult Register(string? returnUrl = null) // Kullanıcıyı geldiği url'e yollar.
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.ReturnUrl = returnUrl;
            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
        {
            registerViewModel.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/"); // Orada bir şey yoksa yani aslında returnUrl nullsa
            if (ModelState.IsValid)
            {
                var user = new AppUser { Email = registerViewModel.Email, UserName = registerViewModel.UserName };

                IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false); // isPersistent tarayıcıyı kapattığında kalıcı bir cookie bırakır.
                    return LocalRedirect(returnUrl); // SignIn/SignOut işleminin bir parçası olarak, bir returnUrl kullanarak yapılıyorsa, LocalRedirect yeniden yönlendirme için önerilen yöntemdir.
                }
                else
                {
                    result.Errors.ToList().ForEach(f => ModelState.AddModelError(f.Code, f.Description)); // FrontEnd'e hata mesajlarını göstermek için var bu metot
                }
            }
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
