using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SQLite;
namespace Project5.Models
{
    public class User
    {
        [PrimaryKey,NotNull]
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string mobileNo { get; set; }
        
        public string password { get; set; }
    }

}
