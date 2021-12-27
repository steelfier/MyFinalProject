using MyFinalProject.BLL.ViewModels.TechVM;
using MyFinalProject.BLL.Interfaces;
using MyFinalProject.BLL.Infrastructure;
using MyFinalProject.BLL.ViewModels.UserVM;
using MyFinalProject.DAL;
using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.Services
{
    public class TechService : ITechService
    {
        private AppDbContext db { get; set; }

        public TechService(AppDbContext _db)
        {
            db = _db;
        }

        public void CreateTech(CreateTechVM tech)
        {
            try
            {
                var newTech = new Tech()
                {
                    Name = tech.Name,
                    Category = tech.Category,
                    Comment = tech.Comment,
                    Parameters = tech.Parameters
                };
                db.Techs.Add(newTech);
                UserTech userTech = new UserTech() { TechId = newTech.TechId, UserID = StaticUserAccount.Id };
                db.UsersTech.Add(userTech);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetTechParameters(CreateTechVM tech) //!!!
        {
            try
            {
                var newTech = new Tech()
                {
                    Name = tech.Name,
                    Category = tech.Category,
                    Comment = tech.Comment,
                    Parameters = tech.Parameters
                };
                db.Techs.Add(newTech);
                db.SaveChanges();
                UserTech userTech = new UserTech() { TechId = newTech.TechId, UserID = StaticUserAccount.Id };
                db.UsersTech.Add(userTech);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddTechToUser(Tech tech) //!!!
        {
            try
            {
               db.Techs.Add(tech);
               db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveTech(Tech tech)
        {
            try
            {
                db.Techs.Remove(tech);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

