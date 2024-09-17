using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compacts.Simple.Identity.EF
{
    public class UserRoles<TUser> where TUser : IdentityUser
    {
        public TUser ApplicationUser { get; set; }
        public List<string> Roles { get; set; }
    }
}
