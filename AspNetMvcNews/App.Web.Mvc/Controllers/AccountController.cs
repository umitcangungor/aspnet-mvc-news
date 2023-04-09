using App.Data;
using App.Data.Abstract;
using App.Web.Mvc.Models.ViewModels;
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
    }
}
