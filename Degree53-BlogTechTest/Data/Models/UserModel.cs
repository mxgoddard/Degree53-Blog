using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Degree53_BlogTechTest.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
