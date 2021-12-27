using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class RemoteButton
    {
        [Key]
        public Guid RemButId { get; set; } = Guid.NewGuid();
        public Guid RemId { get; set; }
        public virtual Remote Remote { get; set; }
        public string Name { get; set; }
    }
}
