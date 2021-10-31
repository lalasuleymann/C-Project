using Project1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
    partial class Pharmacy
    {
        public void AddDrug(Drug drug)
        {
            Drugs.Add(drug);
        }

        public bool DrugInfo(string name)
        {
            var drugs = Drugs.FindAll(x => x.Name == name);
            if (drugs.Count == 0)
            {
                Extensions.Color("No Info found.", ConsoleColor.Red);
                return false;
            }

            Extensions.Color($"Info about {Name}: ", ConsoleColor.Cyan);
            foreach (var item in drugs)
            {
                Extensions.Color(item.ToString(), ConsoleColor.Green);
            }
            return true;
        }
        
        public void ShowDrugItems()
        {
            if (Drugs.Count == 0)
            {
                Extensions.Color($"No Drugs exist in {Name} ", ConsoleColor.Red);
                return;
            }

            Extensions.Color($"Drug list in {Name}: ", ConsoleColor.Cyan);
            foreach (var item in Drugs)
            {
                Extensions.Color(item.ToString(), ConsoleColor.Green);
            }
        }

        public bool SaleDrug(string name, int count,int payment) 
        {
            Drug drug = Drugs.Find(x => x.Name == name);
            if (drug == null && drug.Count > count && drug.Price > payment)
            {
                Extensions.Color("You can not buy", ConsoleColor.Red);
                return false;
            }

            Extensions.Color($"Sold Drug- Name: {drug.Name} Count: {drug.Count} Price: {drug.Price}",ConsoleColor.Cyan);
            Drugs.Remove(drug);
            return true;
        }
    }
}
