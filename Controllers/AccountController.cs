using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BasefugeesWebApp.DAL.ApiClients;
using BasefugeesWebApp.DAL.DTO;
using BasefugeesWebApp.Helpers;
using BasefugeesWebApp.Models;
using Hanssens.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasefugeesWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOptions<AppSettingsModel> _appSettings;
        private readonly ILogger<AccountController> _logger;
        public static LocalStorage EncryptedStorage;

        public AccountController(ILogger<AccountController> logger, IOptions<AppSettingsModel> app)
        {
            _logger = logger;
            _appSettings = app;
            WebConfig.ApiUrl = Constants.ApiUrl;
            WebConfig.AlgoliaAppID = Constants.AlgoliaAppID;
            WebConfig.AlgoliaAPIKey = Constants.AlgoliaAPIKey;
            WebConfig.LocalStoragePassword = Constants.LocalStoragePassword;
            WebConfig.LocalStorageSalt = Constants.LocalStorageSalt;

            // setup a configuration with encryption enabled (defaults to 'false')
            // note that adding EncryptionSalt is optional, but recommended
            var config = new LocalStorageConfiguration
            {
                EnableEncryption = true,
                EncryptionSalt = WebConfig.LocalStorageSalt
            };

            // initialize LocalStorage with a password of your choice
            EncryptedStorage = new LocalStorage(config, WebConfig.LocalStoragePassword);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userEmail, string password, string returnUrl = null)
        {
            var userData = new UserLoginModel
            {
                Email = userEmail,
                Password = password
            };

            EncryptedStorage.Store("user-email", userEmail);
            EncryptedStorage.Store("user-password", password);

            ViewData["ReturnUrl"] = returnUrl;

            var userResponse = await ApiClientFactory.Instance.LoginUser(userData);

            // Normally Identity handles sign in, but you can do it directly
            if (ValidateLogin(userResponse))
            {
                var claims = new List<Claim>
                {
                    new Claim("user", userEmail),
                    new Claim("role", "Member")
                };

                await HttpContext.SignInAsync(
                    new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return Redirect("/");
            }

            return View();
        }

        private bool ValidateLogin(UserLoginResponseModel userResponse)
        {
            // For this sample, all logins are successful.
            var token = userResponse.Token;

            EncryptedStorage.Store("user-token", token);

            var isValid = token != "";

            return isValid;
        }

        [HttpGet]
        public async Task<IActionResult> Signin(string userEmail, string password, string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(UserModel userData)
        {
            ViewData["isSuccess"] = false;

            // Does user's email already exist
            var userEmail = new EmailCheckModel
            {
                Email = userData.Email
            };
            bool isAlreadyExist = false;
            isAlreadyExist = await ApiClientFactory.Instance.CheckEmail(userEmail);

            // Normally Identity handles sign in, but you can do it directly
            if (ValidateSignin(userData))
            {
                // display success
                ViewData["isSuccess"] = true;
                return View("Login");
            }

            return View();
        }

        private bool ValidateSignin(UserModel userData)
        {
            // Test password validity
            bool isPasswordValid = userData.Password.Length > 7;

            // For this sample, all logins are successful.
            if (isPasswordValid)
            {
                return true;
            }

            return false;
        }

        public IActionResult AccessDenied(string returnUrl = null)
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}