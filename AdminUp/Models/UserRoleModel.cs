using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Models
{
    public class UserRoleModel
    {
        public IdentityUser User { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
