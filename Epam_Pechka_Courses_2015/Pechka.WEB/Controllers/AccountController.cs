using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pechka.WEB.Models;
using Pechka.WEB.Providers;
using Pechka.WEB.Repository.IRepository;
using Pechka.WEB.Repository.Repository;

namespace Pechka.WEB.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserRepository userRepository;

        public AccountController()
        {
            userRepository=new UserRepository();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    //GetIn(model.Email,model.Password, pechkaRoles.GetRoleOfUser(model.Email));
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Request");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Settings()
        {
            var currentUser = userRepository.GetUserByEmail(User.Identity.Name);
            return View(currentUser);
        }
        
    }

}