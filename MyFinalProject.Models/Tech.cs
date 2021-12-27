using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class Tech
    {
        [Key]
        public Guid TechId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public List<string> Parameters { get; set; }
        public virtual List<UserTech> UserTech { get; set; }
    }
}
