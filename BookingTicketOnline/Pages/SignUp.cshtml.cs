﻿using AutoMapper;
using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using BCrypt.Net;

namespace BookingTicketOnline.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public SignUpModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.User InputUser { get; set; } = new Models.User();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string encryptPassword = BCrypt.Net.BCrypt.HashPassword(InputUser.Password);

            var user = new Models.User
            {
                Username = InputUser.Username,
                FullName = InputUser.FullName,
                Dob = InputUser.Dob,
                PhoneNumber = InputUser.PhoneNumber,
                Email = InputUser.Email,
                Password = encryptPassword,
                Status = "Active",
                RoleId = 2
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["success"] = "Bạn đã tạo tài khoản thành công";

            return RedirectToPage("/Index");
        }
    }
}
