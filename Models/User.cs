using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class User
    {
        public string id { get; set; }
        public string password { get; set; }
        public string room { get; set; }

    }

}