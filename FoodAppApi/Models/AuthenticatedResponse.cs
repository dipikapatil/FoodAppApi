using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Models
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public bool IsAuthSuccesful { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
