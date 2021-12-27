using MyFinalProject.BLL.Interfaces;
using MyFinalProject.BLL.Services;
using MyFinalProject.BLL.ViewModels.TechVM;
using MyFinalProject.BLL.ViewModels.UserVM;
using MyFinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.PL
{ 
public class ConsoleHelper
{
    private IUserService userService { get; set; }
    private ITechService techService { get; set; }

    public ConsoleHelper(AppDbContext _db)
    {
        userService = new UserService(_db);
        techService = new TechService(_db);
    }

    public void GetStartPage()
    {
        Console.WriteLine("Приложение Система управления техникой. Выберите действие:");
        Console.Write("1 - Вход в аккаунт \n2 - Регистрация\n\nВведите номер действия: ");
        var number = Console.ReadLine();
        switch (number)
        {
            case "1":
                {
                    GetLogInPage();
                    break;
                }
            case "2":
                {
                    GetRegisterPage();
                    break;
                }
            default:
                {
                    GetStartPage();
                    break;
                }
        }
    }

    public void GetRegisterPage()
    {
        try
        {
            Console.Clear();
            Console.Write("Регистрация");
            var acc = new AccountVM();
            Console.Write("\nВведите логин: ");
            acc.Login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            acc.PassHash = Console.ReadLine().GetHashCode().ToString();
            userService.RegisterUser(acc);
            GetLogInPage();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка. " + ex.Message);
            Thread.Sleep(3000);
            GetRegisterPage();
        }
    }

    public void GetLogInPage()
    {
        try
        {
            Console.Clear();
            Console.Write("Вход в кабинет");
            var acc = new AccountVM();
            Console.Write("\nВведите логин: ");
            acc.Login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            acc.PassHash = Console.ReadLine().GetHashCode().ToString();
            Console.WriteLine(acc.PassHash);
            GetMainMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка. " + ex.Message);
            Thread.Sleep(3000);
            GetLogInPage();
        }
    }

        public void GetMainMenu()
        {
            Console.Clear();
            Console.Write("Действия: \n1 - Добавить технику\n2 - Показать мою технику\n3 - Выйти из кабинета\n\nВведите номер действия: ");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    {
                        AddTechPage();
                        break;
                    }
                case "2":
                    {
                        //GetMyTechPage();
                        break;
                    }
                case "3":
                    {
                        GetStartPage();
                        break;
                    }
                default:
                    {
                        GetMainMenu();
                        break;
                    }
            }
        }
        public void AddTechPage()
        {
            Console.Clear();
            Console.Write("Действия: \n1 - Добавить новую технику\n2 - Добавить существующую технику\n3 - Главное меню\n\nВведите номер действия: ");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    {
                        AddNewTechPage();
                        break;
                    }
                case "2":
                    {
                        //AddExistingTechPage();
                        break;
                    }
                case "3":
                    {
                        GetMainMenu();
                        break;
                    }
                default:
                    {
                        AddTechPage();
                        break;
                    }
            }
        }
        public void AddNewTechPage()
    {
        try
        {
            Console.Clear();
            var newTech = new CreateTechVM();
            Console.Write("Введите название техники: ");
            newTech.Name = Console.ReadLine();
            Console.Write("Введите категорию: ");
            newTech.Category = Console.ReadLine();
            Console.Write("Введите комментарий: ");
            newTech.Comment = Console.ReadLine();
            techService.CreateTech(newTech);
            //GetMyTechPage();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка. " + ex.Message);
            Thread.Sleep(3000);
            GetLogInPage();
        }
    }

    /*public void AddExistingTechPage()
    {
        try
        {
            Console.Clear();
            var notes = noteService.GetAllNotesByUser();
            foreach (var note in notes)
            {
                Console.WriteLine($"---------------------------\nID: {note.Id}\nНазвание: {note.Name}\nКатегория: {note.CreationTime.Hour}\nКомментарий: {}");
            }
            Console.Write("---------------------------\n\nДействия: \n1 - Добавить себе\n2 - Посмотреть параметры\n3 - Главное меню\n\nВведите номер действия: ");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    {
                        Console.Write("Введите ID техники: ");
                        GetTech(Console.ReadLine());
                        AddTechToUser()
                        break;
                    }
                case "2":
                    {
                        GetParametersPage();
                        break;
                    }
                case "3":
                    {
                        GetMainMenu();
                        break;
                    }
                default:
                    {
                            AddExistingTechPage();
                        break;
                    }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка. " + ex.Message);
            Thread.Sleep(3000);
            GetLogInPage();
        }
    }*/
        /*public void GetParametersPage()
        {
            try
            {
                Console.Clear();
                var notes = noteService.GetAllNotesByUser();
                foreach (var note in notes)
                {
                    Console.WriteLine($"---------------------------\nID: {note.Id}\nНазвание: {note.Name}\nКатегория: {note.CreationTime.Hour}\nКомментарий: {}");
                }
                Console.Write("---------------------------\n\nДействия: \n1 - Изменить параметр\n2 - Главное меню\n\nВведите номер действия: ");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {
                            Console.Write("Введите ID техники: ");
                            GetNotePage(Console.ReadLine());
                            break;
                        }
                    case "2":
                        {
                            GetMainMenu();
                            break;
                        }
                    default:
                        {
                            GetParametersPage();
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка. " + ex.Message);
                Thread.Sleep(3000);
                GetLogInPage();
            }
        }*/
        /*public void GetMyTechPage()
    {
        try
        {
            Console.Clear();
            var note = noteService.GetNote(noteId);
                foreach (var note in notes)
                {
                    Console.WriteLine($"---------------------------\nID: {note.Id}\nНазвание: {note.Name}\nКатегория: {note.CreationTime.Hour}\nКомментарий: {}");
                }
                Console.Write("---------------------------\n\nДействия: \n1 - Параметры техники\n2 - Добавить пульт\n3 - Управление техникой\n3 - Удалить технику\n\nВыберите номер действия: ");
            var number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    {
                        GetParametersPage();
                        break;
                    }
                case "2":
                    {
                        AddRemotePage();
                        break;
                    }
                case "3":
                    {
                        UsingRemotePage();
                        break;
                    }
                case "4":
                    {
                        DeleteTechPage();
                        break;
                    }
                default:
                    {
                        GetMyTechPage();
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка. " + ex.Message);
            Thread.Sleep(3000);
            GetLogInPage();
        }
    }*/
        /*public void UsingRemotePage()
        {
            try
            {
                Console.Clear();
                var note = noteService.GetNote(noteId);
                foreach (var note in notes)
                {
                    Console.WriteLine($"---------------------------\nНомер кнопки: {note.Id}\nДействие: {note.Name}");
                }
                Console.Write("---------------------------\n\nВыберите номер кнопки: ");
                var number = Console.ReadLine();
                foreach (var note in notes)
                {
                    if (note == number)
                    {
                        Console.WriteLine($"Кнопка {note.Name} использована успешно");
                        Thread.Sleep(1000);
                        GetMyTechPage();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка. " + ex.Message);
                Thread.Sleep(3000);
                GetLogInPage();
            }
        }*/
        /*public void DeleteTechPage()
        {
            try
            {
                Console.Clear();
                var note = noteService.GetNote(noteId);
                Console.WriteLine($"Вы уверены, что хотите удалить {}?");
                Console.Write("---------------------------\n1 - Да\n2 - Нет\n\nВыберите номер действия: ");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {
                            RemoveTech(Tech tech);
                            Console.Write("Техника успешно удалена");
                            Thread.Sleep(1000);
                            GetMyTechPage();
                            break;
                        }
                    case "2":
                        {
                            GetMyTechPage();
                            break;
                        }
                    default:
                        {
                            DeleteTechPage();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка. " + ex.Message);
                Thread.Sleep(3000);
                GetLogInPage();
            }
        }*/
        /*public void AddRemotePage()
        {
            try
            {
                Console.Clear();
                var note = noteService.GetNote(noteId);
                foreach (var note in notes)
                {
                    Console.WriteLine($"Пульт успешно добавлен. Для корректной работы нужно добавить кнопки.");
                }
                Console.Write("---------------------------\n1 - Да\n2 - Нет\n\nВыберите номер действия: ");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {
                            Console.Write("Техника успешно удалена");
                            Thread.Sleep(1000);
                            GetMyTechPage();
                            break;
                        }
                    case "2":
                        {
                            GetMyTechPage();
                            break;
                        }
                    default:
                        {
                            DeleteTechPage();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка. " + ex.Message);
                Thread.Sleep(3000);
                GetLogInPage();
            }
        }*/
    }
}
