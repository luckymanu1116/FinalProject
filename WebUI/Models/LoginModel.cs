﻿using System;
namespace WebUI.Models
{
	public class LoginModel
	{
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginModel(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}

