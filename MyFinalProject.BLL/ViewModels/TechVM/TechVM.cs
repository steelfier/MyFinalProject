using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.ViewModels.TechVM
{
    public class TechVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public List<string> Parameters { get; set; }
        //public virtual Remote Remote { get; set; }
        public TechVM(Tech tech)
        {
            Id = tech.TechId;
            Name = tech.Name;
            Category = tech.Category;
            Comment = tech.Comment;
            Parameters = tech.Parameters;
            //Remote = tech.Remote;
        }
    }
}
