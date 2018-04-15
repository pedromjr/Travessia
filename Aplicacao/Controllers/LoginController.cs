using Core;
using Entities;
using System;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class LoginController : BaseAnonymousController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            ViewBag.LoginError = false;
            ViewBag.Title = "Login";
            UserLoginCredentials credentials = new UserLoginCredentials();

            return View(credentials);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserLoginCredentials model)
        {
            ViewBag.LoginError = false;
            if (!ModelState.IsValid)
                return View(model);

            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError("", "Senha e Confirmação de senhas não estão iguais.");
                return View("SignIn", model);
            }

            using (UserBusiness userBusiness = new UserBusiness())
            {
                GTUser user = userBusiness.GetUserByLogin(model.Login);
                if (user != null)
                {
                    ModelState.AddModelError("", string.Format("Usuário já está cadastrado na base com o email '{0}'.", user.Email));
                    return View("SignIn", model);
                }

                user = new GTUser()
                {
                    Email = model.Email,
                    Login = model.Login,
                    Name = model.Name,
                    Password = model.Password
                };

                userBusiness.CreateUser(user);
                user = userBusiness.GetUserByLogin(model.Login);

                //Checa por erros de domínio
                if (this.CheckForDomainErrors(userBusiness))
                {
                    ViewBag.LoginError = true;
                    return View("SignIn", model);
                }

                //Salva o estado do usuário em sessão
                this.SetGTUser(user);

            }
            //Cria um cookie de autenticação para manter a sessão do usuário
            FormsAuthentication.SetAuthCookie(model.Login, false);
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignIn(UserLoginCredentials model, string returnUrl)
        {
            ViewBag.LoginError = false;
            if (!ModelState.IsValid)
                return View(model);

            using (UserBusiness userBusiness = new UserBusiness())
            {
                GTUser user = null;
                if (userBusiness.AuthenticateUser(model.Login, model.Password))
                    user = userBusiness.GetUserByLogin(model.Login);

                //Checa por erros de domínio
                if (this.CheckForDomainErrors(userBusiness))
                {
                    ViewBag.LoginError = true;
                    return View(model);
                }

                //Salva o estado do usuário em sessão
                this.SetGTUser(user);

            }
            //Cria um cookie de autenticação para manter a sessão do usuário
            FormsAuthentication.SetAuthCookie(model.Login, false);

            if (!String.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            this.ClearSession();
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SessionExpired()
        {
            FormsAuthentication.SignOut();
            this.ClearSession();
            return RedirectToAction("SignIn");
        }
    }
}