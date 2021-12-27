using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class Remote
    {
        [Key]
        public Guid RemId { get; set; } = Guid.NewGuid();
        public Guid TechId { get; set; } 
        public virtual Tech Tech { get; set; }
        public string Name { get; set; }
        public virtual List<RemoteButton> RemoteButtons { get; set; }
    }
}
