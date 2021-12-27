using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.ViewModels.TechVM
{
    public class CreateTechVM
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public List<string> Parameters { get; set; }
    }
}
