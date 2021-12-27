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
                UserTech userTech = new UserTech() { TechId = newTech.TechId, UserId = StaticUserAccount.Id };
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
                UserTech userTech = new UserTech() 
                { 
                    TechId = newTech.TechId, 
                    UserId = StaticUserAccount.Id 
                };
                db.UsersTech.Add(userTech);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TechVM GetTech(string techId)
        {
            try
            {
                var techDb = db.Techs.Find(new Guid(techId));
                if (techDb == null)
                {
                    throw new Exception("Такой техники не существует.");
                }
                var tech = new TechVM(techDb);
                return tech;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddTechToUser(Tech tech)
        {
            try
            {
                UserTech userTech = new UserTech()
                {
                    TechId = tech.TechId,
                    UserId = StaticUserAccount.Id
                };
               db.UsersTech.Add(userTech);
               db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TechAllListVM> GetAllTechByUser()
        {
            try
            {
                var techsFromDb = db.Techs;
                var techList = new List<TechAllListVM>();

                foreach (var techDb in techsFromDb)
                {
                    techList.Add(new TechAllListVM(techDb));
                }

                return techList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TechUserListVM> GetListTechByUser()
        {
            try
            {
                var techsFromDb = db.UsersTech.Where(n => n.UserId == StaticUserAccount.Id);
                var techList = new List<TechUserListVM>();

                foreach (var techDb in techsFromDb)
                {
                    //techList.Add(new TechUserListVM(techDb));
                }

                return techList;
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

