using MyFinalProject.BLL.ViewModels.TechVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.Interfaces
{
    public interface ITechService
    {
        void CreateTech(CreateTechVM tech);
        //List<NoteListItemVM> GetAllNotesByUser();
        //NoteVM GetNote(string noteId);
    }
}
