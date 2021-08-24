using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using dots_server_v2.Data;
using dots_server_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dots_server_v2.Pages.Account
{
    public class RegisterPageModel : PageModel
    {
        private readonly DotsContext _context;

        public class RegisterModel
        {
            [StringLength(16, MinimumLength = 3)]
            public string UserName { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [StringLength(64, MinimumLength = 8)]
            public string Password { get; set; }
        }

        public RegisterPageModel(DotsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterModel NewUser { get; set; }

        public string UiMessage { get; set; } = "Submit";
        public bool RegisterSuccess { get; set; }
        
        public void OnGet()
        {
            
        }

        public async Task<ActionResult> OnPostRegisterAsync()
        {
            if (string.IsNullOrEmpty(NewUser.Email)
                || string.IsNullOrEmpty(NewUser.UserName)
                || string.IsNullOrEmpty(NewUser.Password))
            {
                RegisterSuccess = false;
                UiMessage = "Enter credentials";
                return Page();
            }
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usernameExists = await _context.Users.AnyAsync(u => u.UserName.ToLower() == NewUser.UserName.ToLower());
            if (usernameExists)
            {
                RegisterSuccess = false;
                UiMessage = "Username exists";
                return Page();
            }

            var user = new DotsUser
            {
                UserName = NewUser.UserName,
                Email = NewUser.Email,
                PasswordHash = Helpers.GetHash(NewUser.Password)
            };

            await _context.Users.AddAsync(user);
            if (await _context.SaveChangesAsync() > 0)
            {
                UiMessage = "Account created";
                RegisterSuccess = true;
            }
            else
            {
                UiMessage = "Could not create account :(";
                RegisterSuccess = false;
            }
            
            return Page();
        }

        public async Task<ActionResult> OnPostLoginAsync()
        {
            return Page();
        }
    }
}