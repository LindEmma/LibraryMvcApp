﻿namespace LibraryMvcApp.Models
{
    public class LoginViewModel // for when logging in
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
