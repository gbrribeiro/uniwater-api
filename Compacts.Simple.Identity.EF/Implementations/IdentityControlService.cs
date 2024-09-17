using Compacts.Simple.Identity.EF.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Compacts.Simple.Identity.EF.Implementations
{
    public class IdentityControlService<TUser> : IIdentityControlService<TUser> where TUser : IdentityUser  
    {
        private readonly Jwt jwtOptions;
        private readonly UserManager<TUser> userManager;
        private readonly SignInManager<TUser> signInManager;

        public IdentityControlService(IOptions<Jwt> jwtOptions, UserManager<TUser> userManager, SignInManager<TUser> signInManager)
        {
            this.jwtOptions = jwtOptions.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task DeleteUserByEmailAsync([FromRoute] string email)
        {
            var user = await userManager.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            await userManager.DeleteAsync(user);
        }

        public async Task<List<TUser>> GetAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<TUser> GetByIdAsync(int id)
        {
            var user = await userManager.Users.Where(u => u.Id == id.ToString()).FirstOrDefaultAsync();
            return user;
        }

        public async Task<string> LoginUser(string email, string password)
        {
            //Creates an empty response
            var response = new Jwt();

            var result = await signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
            {
                return "Failed to login";
            }

            //Get claims
            var claims = await _getUserClaims(email);

            //Assign generated token to the response
            var token = _generateToken(claims);
            return token;
        }

        public async Task<bool> PromoteUserByEmail(string email)
        {
            //TODO: LOG
            var user = userManager.Users.Where(us => us.Email == email).FirstOrDefault();
            await userManager.AddToRoleAsync(user, "Admin");
            return true;
        }

        public async Task<string> RegisterUser(TUser user)
        {

            await userManager.CreateAsync(user);

            //Creates an empty response
            var response = new Jwt();

            //Enables user
            await userManager.SetLockoutEnabledAsync(user, false);

            //Get claims
            var claims = await _getUserClaims(user.Email);
            //Assign generated token to the response
            var token = _generateToken(claims);
            return token;
        }

        public async Task<bool> RemoveAdminByEmail(string email)
        {
            //TODO: LOG
            var user = userManager.Users.Where(us => us.Email == email).FirstOrDefault();
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return true;
        }

        public Task<TUser> UpdateUserAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        private string _generateToken(IEnumerable<Claim> userClaims)
        {
            //Creates the token using the data informed
            var token = new JwtSecurityToken
                (
                    issuer: jwtOptions.Issuer,
                    audience: jwtOptions.Audience,
                    claims: userClaims,
                    expires: DateTime.Now.AddSeconds(jwtOptions.Expiration),
                    notBefore: DateTime.Now,
                    signingCredentials: jwtOptions.SigningCredentials
                );

            //Write the token as string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IEnumerable<Claim>> _getUserClaims(string email)
        {
            //Get user by email
            var user = await userManager.FindByEmailAsync(email);

            //Get user roles
            IEnumerable<string> userRoles = await userManager.GetRolesAsync(user!);

            //Apply it to claims
            List<Claim> claims = new List<Claim>();
            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

    }
}
