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
        public Guid TechId { get; set; }
        public string Name { get; set; }

        public TechAllListVM(Tech tech)
        {
            TechId = tech.TechId;
            Name = tech.Name;
        }
    }
}
