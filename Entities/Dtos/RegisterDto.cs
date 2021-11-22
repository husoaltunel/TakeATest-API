﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RegisterDto : IDto
    {
        public string Username { get;set;}
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
