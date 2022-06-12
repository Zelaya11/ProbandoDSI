// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FransfordSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace FransfordSystem.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IEmailSender _emailSender;
        public string mensaje { get; set; }

        public ForgotPasswordModel(UserManager<Usuario> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]

            
            public string Email { get; set; }
            

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(Input.Email);
                var userByUser = await _userManager.FindByNameAsync(Input.Email);

                if (userByEmail == null || !(await _userManager.IsEmailConfirmedAsync(userByEmail)) )
                {
                    mensaje = "El Correo No Se Encontro";
                    return RedirectToPage("./ForgotPassword",mensaje);
                }
                else if (userByUser == null || !(await _userManager.IsEmailConfirmedAsync(userByUser)))
                {
                    mensaje = "El Usuario No Se Encontro";
                    return RedirectToPage("./ForgotPassword",mensaje);
                }

                
                if (userByEmail != null)
                {
                    return RedirectToPage("./ForgotPasswordConfirmation", userByEmail);
                }

                return RedirectToPage("./ForgotPasswordConfirmation",userByUser);
            }

            return Page();
        }
    }
}
