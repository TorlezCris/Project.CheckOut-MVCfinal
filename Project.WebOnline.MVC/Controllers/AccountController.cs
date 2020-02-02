using Newtonsoft.Json;
using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using Project.WebOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.WebOnline.MVC.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(/*ILog log, */IUnitOfWork unit) : base(/*log,*/ unit)
        {
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new UserViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserViewModel user)
        {
            if (!ModelState.IsValid) return View(user);
            var validUser = _unit.UserWeb.ValidateUser(user.Email, user.Password);

            if (validUser == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(user);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, validUser.Email),
                new Claim(ClaimTypes.Name, $"{validUser.Name} {validUser.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, validUser.Email),
                new Claim(ClaimTypes.UserData, validUser.UserId.ToString())
            },
            "ApplicationCookie");

            //Get token
            var url = "http://localhost:49488/";
            var token = await GetToken(user.Email, user.Password, url);

            //Add access token if exists like a claim
            if (token != null) identity.AddClaim(new Claim(ClaimTypes.Authentication, token.access_token));

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignIn(identity);

            return RedirectToLocal(user.ReturnUrl);
        }

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Store");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterUserViewModel userView)
        {
            if (!ModelState.IsValid) return View(userView);

            UserWeb user = new UserWeb
            {
                Email = userView.Email,
                Name = userView.FirstName,
                LastName = userView.LastName,
                Password = userView.Password
            };
            var validUser = _unit.UserWeb.CreateUser(user);
            if (validUser == null)
            {
                ModelState.AddModelError("Error", "No se pudo crear el usuario");
                return View(user);
            }
            /*sign in*/
            /*
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, validUser.Email),
                new Claim(ClaimTypes.Name, $"{validUser.FirstName} {validUser.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, validUser.Email)
            },
            "ApplicationCookie");

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignIn(identity);
            */

            /*redireccionar al login*/
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Store");
        }

        public async Task<Token> GetToken(string user, string password, string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var urlToken = $"{url}token";

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlToken);
                    var data = new Dictionary<string, string>
                    {
                        { "grant_type", "password" },
                        { "username", user },
                        { "password", password }
                    };
                    httpRequest.Content = new FormUrlEncodedContent(data);
                    var r = await client.SendAsync(httpRequest);
                    if (r.StatusCode == System.Net.HttpStatusCode.InternalServerError || r.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }
                    string jsonString = await r.Content.ReadAsStringAsync();
                    Token responseData = JsonConvert.DeserializeObject<Token>(jsonString);

                    return responseData;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}