using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class UserTech
    {
        [Key]
        public Guid UserTechId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid TechId { get; set; }
        public virtual Tech Tech { get; set; }

    }
}
