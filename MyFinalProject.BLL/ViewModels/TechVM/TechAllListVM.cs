using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.ViewModels.TechVM
{
    public class TechAllListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

        public TechAllListVM(Tech tech)
        {
            Id = tech.TechId;
            Name = tech.Name;
        }
    }
}
