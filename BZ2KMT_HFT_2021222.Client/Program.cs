using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Repository;
using ConsoleTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BZ2KMT_HFT_2021222.Client
{
    internal class Program
    {
        static CarClient carClient;
        static BrandClient brandClient;
        static LoanClient loanClient;
        static PersonClient personClient;
        static StatClient statClient;
        static void List(string entity)
        {
            try
            {
                if(entity == "Car")
                    carClient.ReadAll();
                else if(entity == "Brand")
                    brandClient.ReadAll();
                else if(entity == "Loan")
                    loanClient.ReadAll();
                else if(entity == "Person")
                    personClient.ReadAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            try
            {
                if (entity == "Car")
                    carClient.Update();
                else if (entity == "Brand")
                    brandClient.Update();
                else if (entity == "Loan")
                    loanClient.Update();
                else if (entity == "Person")
                    personClient.Update();
                Console.WriteLine("Item updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            try
            {
                if (entity == "Car")
                    carClient.Create();
                else if (entity == "Brand")
                    brandClient.Create();
                else if (entity == "Loan")
                    loanClient.Create();
                else if (entity == "Person")
                    personClient.Create();
                Console.WriteLine("Item created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            try
            {
                if (entity == "Car")
                    carClient.Delete();
                else if (entity == "Brand")
                    brandClient.Delete();
                else if (entity == "Loan")
                    loanClient.Delete();
                else if (entity == "Person")
                    personClient.Delete();
                Console.WriteLine("Item deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void Read(string entity)
        {
            try
            {
                if (entity == "Car")
                    carClient.Read();
                else if (entity == "Brand")
                    brandClient.Read();
                else if (entity == "Loan")
                    loanClient.Read();
                else if (entity == "Person")
                    personClient.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void Stat(string entity)
        {
            try
            {
                if (entity == "AvgCostByPerson")
                    statClient.AvgCostByPerson();
                else if (entity == "BrandsWithCarReleaseDescending")
                    statClient.BrandsWithCarReleaseDescending();
                else if (entity == "MaxCostForLoan")
                    statClient.MaxCostForLoan();
                else if (entity == "PersonWithMostLoans")
                    statClient.PersonWithMostLoans();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string url = "http://localhost:40003/";
            carClient = new CarClient(url);
            brandClient = new BrandClient(url);
            loanClient = new LoanClient(url);
            personClient = new PersonClient(url);
            statClient = new StatClient(url);

            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Read", () => Read("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Read", () => Read("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var loanSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Loan"))
                .Add("Read", () => Read("Loan"))
                .Add("Create", () => Create("Loan"))
                .Add("Delete", () => Delete("Loan"))
                .Add("Update", () => Update("Loan"))
                .Add("Exit", ConsoleMenu.Close);

            var personSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Person"))
                .Add("Read", () => Read("Person"))
                .Add("Create", () => Create("Person"))
                .Add("Delete", () => Delete("Person"))
                .Add("Update", () => Update("Person"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("AverageCostByPerson", () => Stat("AvgCostByPerson"))
                .Add("BrandsWithCarReleaseDescending", () => Stat("BrandsWithCarReleaseDescending"))
                .Add("MaxCostForLoan", () => Stat("MaxCostForLoan"))
                .Add("PersonWithMostLoans", () => Stat("PersonWithMostLoans"))
                .Add("", () => Stat(""))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brand", () => brandSubMenu.Show())
                .Add("Loan", () => loanSubMenu.Show())
                .Add("Person", () => personSubMenu.Show())
                .Add("Stat", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
                
        }
    }
}
