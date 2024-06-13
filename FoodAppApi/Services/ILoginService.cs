using FoodAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
   public interface ILoginService
    {
        Task<AuthenticatedResponse> Login(User loginRequest);
        public List<User> GetUser();
    }
}
