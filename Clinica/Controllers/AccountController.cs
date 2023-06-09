﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Clinica.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;

namespace Clinica.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ModelDB db = new ModelDB();
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Isso não conta falhas de login em relação ao bloqueio de conta
            // Para permitir que falhas de senha acionem o bloqueio da conta, altere para shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Tentativa de login inválida.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Exija que o usuário efetue login via nome de usuário/senha ou login externo
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // O código a seguir protege de ataques de força bruta em relação aos códigos de dois fatores. 
            // Se um usuário inserir códigos incorretos para uma quantidade especificada de tempo, então a conta de usuário 
            // será bloqueado por um período especificado de tempo. 
            // Você pode configurar os ajustes de bloqueio da conta em IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Código inválido.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar um email com este link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmar sua conta", "Confirme sua conta clicando <a href=\"" + callbackUrl + "\">aqui</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
            return View(model);
        }






        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterM()
        {
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome");
            ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "Nome");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Medico")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterM(UniaoRegistroProfissional model, [Bind(Include = "IdCidade,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2")] tbProfissional tbProfissional,
            [Bind(Include = "IdPlano")] tbContrato tbContrato, [Bind(Include = "IdCidade")] tbCidade tbCidade)//, [Bind(Include = "IdTipoProfissional")] tbTipoProfissional tbTipoProfissional
        {
            try
            {
                ModelState.Remove("tbProfissional.IdUser");
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.RegisterViewModel.Email, Email = model.RegisterViewModel.Email };
                    IdentityUserRole iur = new IdentityUserRole();
                    iur.RoleId = "02";
                    iur.UserId = user.Id;
                    user.Roles.Add(iur);
                    var result = await UserManager.CreateAsync(user, model.RegisterViewModel.Password);
                    if (result.Succeeded)
                    {
                        //Contrato//
                        tbContrato.DataInicio = DateTime.UtcNow;
                        tbContrato.DataFim = tbContrato.DataInicio.Value.AddMonths(1);
                        //tbContrato.IdPlano = (int)(Models.Enum.Plan.MedicoParcial.Equals(true) ? Models.Enum.Plan.MedicoTotal : Models.Enum.Plan.MedicoParcial);
                        db.tbContrato.Add(tbContrato);
                        db.SaveChanges();
                        //
                        //Profissional
                        tbProfissional.IdContrato = tbContrato.IdContrato;
                        tbProfissional.IdUser = user.Id;
                        tbProfissional.IdCidade = tbCidade.IdCidade;
                       
                        //tbProfissional.IdTipoProfissional = tbTipoProfissional.IdTipoProfissional;
                        db.tbProfissional.Add(tbProfissional);
                        db.SaveChanges();

                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
                        // Enviar um email com este link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirmar sua conta", "Confirme sua conta clicando <a href=\"" + callbackUrl + "\">aqui</a>");
                        if (User.IsInRole("Medico"))
                        {
                            return RedirectToAction("Index2", "Home");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
                // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
                ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome");
                ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "Nome");
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", $"Ocorreu um erro.Não foi possivel salvar os dados.Tente mais tarde!{ex}");
                ViewBag.Erro = ex.Message;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Erro = ex.Message;
            }

            return View(model);
        }



        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterN()
        {
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome");
            ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "Nome");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Nutricionista")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterN(UniaoRegistroProfissional model, [Bind(Include = "IdCidade,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2")] tbProfissional tbProfissional,
            [Bind(Include = "IdPlano")] tbContrato tbContrato, [Bind(Include = "IdCidade")] tbCidade tbCidade)//, [Bind(Include = "IdTipoProfissional")] tbTipoProfissional tbTipoProfissional
        {
            try
            {
                ModelState.Remove("tbProfissional.IdUser");
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.RegisterViewModel.Email, Email = model.RegisterViewModel.Email };
                    IdentityUserRole iur = new IdentityUserRole();
                    iur.RoleId = "03";
                    iur.UserId = user.Id;
                    user.Roles.Add(iur);
                    var result = await UserManager.CreateAsync(user, model.RegisterViewModel.Password);
                    if (result.Succeeded)
                    {
                       
                        //Contrato//
                        tbContrato.DataInicio = DateTime.UtcNow;
                        tbContrato.DataFim = tbContrato.DataInicio.Value.AddMonths(1);
                        tbContrato.IdPlano = (int)Models.Enum.Plan.Nutricional;
                        db.tbContrato.Add(tbContrato);
                        db.SaveChanges();
                        //
                        //Profissional
                        tbProfissional.IdContrato = tbContrato.IdContrato;
                        tbProfissional.IdUser = user.Id;
                        tbProfissional.IdCidade = tbCidade.IdCidade;
                       // tbProfissional.IdTipoProfissional = tbTipoProfissional.IdTipoProfissional;                       
                        db.tbProfissional.Add(tbProfissional);
                        db.SaveChanges();

                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
                        // Enviar um email com este link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirmar sua conta", "Confirme sua conta clicando <a href=\"" + callbackUrl + "\">aqui</a>");
                        if (User.IsInRole("Nutricionista"))
                        {
                            return RedirectToAction("Index3", "Home");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
                // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
                ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome");
                ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "Nome");
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", $"Ocorreu um erro.Não foi possivel salvar os dados.Tente mais tarde!{ex}");
                ViewBag.Erro = ex.Message;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Erro = ex.Message;
            }

            return View(model);
        }



        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Não revelar que o usuário não existe ou não está confirmado
                    return View("ForgotPasswordConfirmation");
                }

                // Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
                // Enviar um email com este link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Redefinir senha", "Redefina sua senha, clicando <a href=\"" + callbackUrl + "\">aqui</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // Se chegamos até aqui e houver alguma falha, exiba novamente o formulário
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Não revelar que o usuário não existe
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Solicitar um redirecionamento para o provedor de logon externo
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Gerar o token e enviá-lo
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Faça logon do usuário com este provedor de logon externo se o usuário já tiver um logon
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Se o usuário não tiver uma conta, solicite que o usuário crie uma conta
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Obter as informações sobre o usuário do provedor de logon externo
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Auxiliares
        // Usado para proteção XSRF ao adicionar logons externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}