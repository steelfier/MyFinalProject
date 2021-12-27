using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string PassHash { get; set; }
        public virtual List<UserTech> UserTech { get; set; }
        //public string Email { get; set; }
    }
}
