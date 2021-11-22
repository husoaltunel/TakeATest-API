﻿using Core.Entities.Abstract;
using Core.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class LoginInfoDto : IDto
    {
        public string Username { get;set;}
        public AccessToken AccessToken { get;set;}
    }
}
