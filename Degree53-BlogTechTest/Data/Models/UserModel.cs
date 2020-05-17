using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Degree53_BlogTechTest.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
