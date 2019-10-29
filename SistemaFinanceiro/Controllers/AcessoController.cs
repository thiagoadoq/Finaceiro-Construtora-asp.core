using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Models;

namespace SistemaFinanceiro.Controllers
{
    public class AcessoController : Controller
    {
        private AppDbContext _Context;

        public AcessoController(AppDbContext context)
        {
            _Context = context;
        }


        public IActionResult Index(string returnUrl)
        {
            ViewBag.returUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AcessoModel model, string returnUrl)
        {

            var usuario = _Context.Usuario.FirstOrDefault(c => c.Email == model.Email && c.Senha == model.Senha);

            if (usuario == null)
            {
                ViewBag.Messagen = "Usúario ou senha invalido.";
                ViewBag.returUrl = returnUrl;
                return View(model);
            }

            var claims = new List<Claim>
                {
                    new Claim("sub", usuario.Id.ToString()),
                    new Claim("user", usuario.Email),
                    new Claim("name", usuario.Nome),
                    new Claim("email", usuario.Email)
                };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")),
                new AuthenticationProperties
                {
                    IsPersistent = true
                });


            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }

        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}