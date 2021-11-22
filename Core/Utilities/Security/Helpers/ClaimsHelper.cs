﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Helpers
{
    public class ClaimsHelper
    {
        public static List<Claim> SetClaims(User user,List<Claim> claims, List<OperationClaim> userClaims,List<Role> roles)
        {
            claims.Add(new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.ToString()));
            claims.Add(new Claim(type: ClaimTypes.Name, value: user.Username));
            claims.Add(new Claim(type: ClaimTypes.Email, value: user.Email));
            userClaims.ForEach(claim => claims.Add(new Claim("claim", value: claim.Name)));
            roles.ForEach(role => claims.Add(new Claim(type: ClaimTypes.Role, value: role.Name)));
            return claims;
        }
    }
}
