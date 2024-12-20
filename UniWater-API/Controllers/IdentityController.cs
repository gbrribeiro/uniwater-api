﻿using Compacts.Simple.Identity.EF;
using Compacts.Simple.Identity.EF.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UniWater_API.Data;
using UniWater_API.Models;
using UniWater_API.Models.Identity;

namespace UniWater_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IdentityController
    {
        private readonly IIdentityControlService<AppUser> identityControlService;

        public IdentityController(IIdentityControlService<AppUser> identityControlService)
        {
            this.identityControlService = identityControlService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginWithCredentials([FromBody] LoginViewModel loginViewModel)
        {
            return await identityControlService.LoginUser(loginViewModel.Username, loginViewModel.Password);
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> RegisterUser([FromBody] RegisterViewModel registerViewModel)
        {
            var newUser = new AppUser
            {
                Email = registerViewModel.Email,
                NormalizedEmail = registerViewModel.Email,
                UserName = registerViewModel.Name
            };
            newUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(newUser, registerViewModel.Password);
            return await identityControlService.RegisterUser(newUser);
        }

        [HttpGet("User")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {

            return await identityControlService.GetAllUsersAsync();
        }
    }
}
