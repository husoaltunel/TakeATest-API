using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDto : IDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
