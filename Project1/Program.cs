using Project1.Models;
using Project1.Utils;
using System;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            while (true)
            {
                Extensions.Color("1 - Create Pharmacy, 2 - Add Drug, 3 - Drug Info, 4 - Show All Drugs, 5 - Sale Drug, 6 - Out", ConsoleColor.Blue);

                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                        break;


                    switch (menu)
                    {
                        case 1:
                            Extensions.Color("Enter Pharmacy Name", ConsoleColor.DarkYellow);
                            string pharmacyName = Console.ReadLine();
                            if (pharmacies.Exists(x => x.Name.ToLower() == pharmacyName.ToLower()))
                            {
                                Extensions.Color("This Pharmacy already exists.", ConsoleColor.Red);
                                goto case 1;
                            }

                            Pharmacy pharmacy = new Pharmacy(pharmacyName);
                            pharmacies.Add(pharmacy);
                            Extensions.Color($"{pharmacyName} created", ConsoleColor.Green);
                            break;
                        case 2:
                            if (pharmacies.Count == 0)
                            {
                                Extensions.Color("No pharmacies exist.", ConsoleColor.Red);
                                goto case 1;
                            }

                            Extensions.Color("Enter Drug Name", ConsoleColor.DarkYellow);
                            string name = Console.ReadLine();
                            Extensions.Color("Enter DrugType", ConsoleColor.DarkYellow);
                            DrugType drugType = new();
                            drugType.TypeName= Console.ReadLine();
                            Extensions.Color("Enter Drug Price", ConsoleColor.DarkYellow);
                            int price = int.Parse(Console.ReadLine());
                            Extensions.Color("Enter Drug Count", ConsoleColor.DarkYellow);
                            int count = int.Parse(Console.ReadLine());
                           
                            enterPharmacyName: 
                            Extensions.Color("List of pharmacies", ConsoleColor.Cyan);
                            foreach (var item in pharmacies)
                            {
                                Extensions.Color(item.ToString(), ConsoleColor.Green);
                            }

                            Extensions.Color("Enter Pharmacy Name you want to add Drug to", ConsoleColor.Cyan);
                            pharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy = pharmacies.Find(x => x.Name == pharmacyName.ToLower());
                            if (existPharmacy==null)
                            {
                                Extensions.Color("Choose existed Pharmacy", ConsoleColor.Red);
                                goto enterPharmacyName;
                            }

                            Drug drug = new Drug(name, drugType, price, count);
                            existPharmacy.AddDrug(drug);
                            Extensions.Color($"{drug} added to {existPharmacy}", ConsoleColor.Green);
                            break;
                        case 3:
                            if (pharmacies.Count == 0)
                            {
                                Extensions.Color("No pharmacies exist.", ConsoleColor.Red);
                                goto case 1;
                            }

                            enterPhamacyInfo:
                            Extensions.Color("List of pharmacies", ConsoleColor.Cyan);
                            foreach (var item in pharmacies)
                            {
                                Extensions.Color(item.ToString(), ConsoleColor.Green);
                            }

                            Extensions.Color("Enter Pharmacy Name", ConsoleColor.DarkYellow);
                            name = Console.ReadLine();
                            existPharmacy = pharmacies.Find(x => x.Name.ToLower() == name.ToLower());
                            if (existPharmacy==null)
                            {
                                Extensions.Color("Choose existed Pharmacy", ConsoleColor.Red);
                                goto enterPhamacyInfo;
                            }

                            searchedDrug:
                            Extensions.Color("Enter Name of Drug you want to Search", ConsoleColor.Cyan);
                            name = Console.ReadLine();
                            if (!existPharmacy.DrugInfo(name))
                            {
                                goto searchedDrug;
                            }
                            break;
                        case 4:
                            if (pharmacies.Count == 0)
                            {
                                Extensions.Color("No pharmacies exist.", ConsoleColor.Red);
                                goto case 1;
                            }

                            foreach (var item in pharmacies)
                            {
                                item.ShowDrugItems();
                            }
                            break;
                        case 5:
                            if (pharmacies.Count == 0)
                            {
                                Extensions.Color("No pharmacies exist.", ConsoleColor.Red);
                                goto case 1;
                            }
                        enterPharmacyName2:
                            Extensions.Color("List of pharmacies", ConsoleColor.Cyan);
                            foreach (var item in pharmacies)
                            {
                                Extensions.Color(item.ToString(), ConsoleColor.Green);
                            }

                            Extensions.Color("Enter Pharmacy Name you want to buy from", ConsoleColor.Cyan);
                            pharmacyName = Console.ReadLine();
                             existPharmacy = pharmacies.Find(x => x.Name == pharmacyName.ToLower());
                            if (existPharmacy == null)
                            {
                                Extensions.Color("Choose existed Pharmacy", ConsoleColor.Red);
                                goto enterPharmacyName2;
                            }

                            enterDrugItem:
                            existPharmacy.ShowDrugItems();

                            Extensions.Color("Enter name of the Drug you want to Buy", ConsoleColor.Cyan);
                            name = Console.ReadLine();
                            Extensions.Color("Enter count of the Drug you want to Buy", ConsoleColor.Cyan);
                            count = int.Parse(Console.ReadLine());
                            Extensions.Color("Enter the payment amount", ConsoleColor.Cyan);
                            int payment = int.Parse(Console.ReadLine());

                            if (!existPharmacy.SaleDrug(name,count,payment))
                            {
                                Extensions.Color("No drug found", ConsoleColor.Red);
                                goto enterDrugItem;
                            }

                            Extensions.Color($"{name} drug has sold", ConsoleColor.Green);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Extensions.Color("Enter from given numbers!", ConsoleColor.Red);
                }
            }
        }
    }
}
