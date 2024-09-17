using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compacts.Simple.Identity.EF.Interfaces
{
    public interface IIdentityControlService<TUser> where TUser : IdentityUser
    {
        public Task<string> LoginUser(string email, string password);
        public Task<bool> PromoteUserByEmail(string email);
        public Task<bool> RemoveAdminByEmail(string email);

        //User Crud
        public Task<string> RegisterUser(TUser user);
        public Task<List<TUser>> GetAllUsersAsync();
        public Task<TUser> GetByIdAsync(int id);
        public Task<TUser> UpdateUserAsync(TUser user);
        public Task DeleteUserByEmailAsync(string email);
    }
}
