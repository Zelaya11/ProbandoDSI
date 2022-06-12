using FransfordSystem.Models;
using FransfordSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FransfordSystem.Controllers
{
    public class PasswordController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        public PasswordController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;

        }
        // Para pedir correo o usuario 
        public async Task<IActionResult> OlvidePass()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> OlvidePass(OlvidePassViewModel olvidePassViewModel)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(olvidePassViewModel.dato);
                var userByUser = await _userManager.FindByNameAsync(olvidePassViewModel.dato);

                if (userByEmail == null || !(await _userManager.IsEmailConfirmedAsync(userByEmail)))
                {
                    ViewData["Mensaje"] = "El Correo No Se Encontro";
                    return View();

                }
                else if (userByUser == null || !(await _userManager.IsEmailConfirmedAsync(userByUser)))
                {
                    ViewData["Mensaje"] = "El Usuario No Se Encontro";
                    return View();

                }

                VerificarDuiViewModel model = new VerificarDuiViewModel();
                model.dato = olvidePassViewModel.dato;

                if (userByEmail != null)
                {
                    return RedirectToAction("pedirDuiyNombre", model);
                }

                return RedirectToAction("pedirDuiyNombre", model);
            }

            return View();
        }

        //Para pedir dui y nombre

        public async Task<IActionResult> pedirDuiyNombre(VerificarDuiViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> pedirDuiyNombrePost(VerificarDuiViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.dato);

                if (user.dui == model.dui && user.nombreTrabajador == model.nombre)
                {
                    CambiarContraViewModel cambiar = new CambiarContraViewModel();
                    cambiar.dato = model.dato;
                    return RedirectToAction("CambiarContra", cambiar);

                }
                ViewData["Mensaje"] = "Los datos no coinciden";
                return View();

            }

            return View();
        }

        //PARA CAMBIAR CONTRASE;A
        public async Task<IActionResult> cambiarContra(CambiarContraViewModel cambiar)
        {
            return View(cambiar);
        }


        public async Task<IActionResult> cambiarContraPost(CambiarContraViewModel cambiar)
        {
            if (ModelState.IsValid)
            {
                if (cambiar.nuevaContra == cambiar.repetirContra)
                {
                    var usuario = await _userManager.FindByEmailAsync(cambiar.dato);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                    var result = await _userManager.ResetPasswordAsync(usuario, token,cambiar.nuevaContra);
                    return RedirectToAction("Identity/Account/Login");
                }




                return View(cambiar);
            }

            return View();


        }
    }
}

