using FoodAppApi.BussinessLayer;
using FoodAppApi.Context;
using FoodAppApi.Helpers;
using FoodAppApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public class LoginService : ILoginService
    {
        private FoodContext _context;
        private readonly IConfiguration _configuration;
        public LoginService(FoodContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<User> GetUser()
        {
            List<User> users;
            try
            {
                users = _context.Set<User>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }

        public async Task<AuthenticatedResponse> Login(User loginRequest)
        {
            var users = GetUser().SingleOrDefault(user => user.IsActive && user.UserName == loginRequest.UserName);
            if (users == null)
            {
                return null;
            }
            var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Passwsord, users.PasswordSalt);
            if (users.Passwsord != passwordHash)
            {
                return null; 
            }
            Jwthandler jwt = new Jwthandler(_configuration);
            var token = await Task.Run(() => jwt.GenerateToken(loginRequest));
            return new AuthenticatedResponse  { IsAuthSuccesful= true, Token = token };         
        }
    }
}
