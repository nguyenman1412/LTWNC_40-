using SocialMedia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialMedia.Controllers
{
    public class SecurityController : Controller
    {
        private ISecurityService _service = null;
        public SecurityController(ISecurityService service)
        {
            _service = service;
        }

        // GET: Security
        public ActionResult Logon()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            this.Session.Clear();
            return RedirectToAction("Logon");

        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Message = "User registered successfully.";
                _service.SaveUserToDB(model);
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Logon(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_service.IsValidUser(model))
                {
                    this.Session.Add("Username", model.Username);
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }
    }
}