using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Repository;
using ConsoleTools;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BZ2KMT_HFT_2021222.Client
{
    internal class Program
    {
        static CarClient carClient;
        static BrandClient brandClient;
        static LoanClient loanClient;
        static void List(string entity)
        {        
            if(entity == "Car")
            {
                carClient.ReadAll();
            }
            else if(entity == "Brand")
            {
                brandClient.ReadAll();
            }
            else if(entity == "Loan")
            {
                loanClient.ReadAll();
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var ctx = new CarRentDbContext();

            var carRepository = new CarRepository(ctx);
            var brandRepository = new BrandRepository(ctx);
            var loanRepository = new LoanRepository(ctx);

            var carLogic = new CarLogic(carRepository);
            var brandLogic = new BrandLogic(brandRepository);
            var loanLogic = new LoanLogic(loanRepository);

            carClient = new CarClient(carLogic);
            brandClient = new BrandClient(brandLogic);
            loanClient = new LoanClient(loanLogic);


            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var loanSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Loan"))
                .Add("Create", () => Create("Loan"))
                .Add("Delete", () => Delete("Loan"))
                .Add("Update", () => Update("Loan"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brand", () => brandSubMenu.Show())
                .Add("Loan", () => loanSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
                
        }
    }
}
