using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public class TaxRepository : ITax
    {
        List<Taxes> taxData = new List<Taxes>();
        public List<Taxes> ReadAll()
        {
            LoadTax();
            return taxData;
        }

        public Taxes ReadByID(string stateAbbr)
        {
            ReadAll();
            var results = (from taxes in taxData
                           where taxes.StateAbbreviation == stateAbbr
                           select taxes).FirstOrDefault();
            return results;
        }
        private void LoadTax()
        {
            string path = @"C:\TSG-PlantSampleData\Taxes.txt";

            taxData = new List<Taxes>();
            string[] rows = File.ReadAllLines(path);
            for (int i = 1; i < rows.Length; i++)
            {
                Taxes tax = new Taxes();
                tax = ConvertTextToObject(rows[i]);
                taxData.Add(tax);
            }
        }
        private Taxes ConvertTextToObject(string line)
        {
            string[] columns = line.Split(',');
            Taxes tax = new Taxes();
            tax.StateAbbreviation = columns[0];
            tax.StateName = columns[1];
            tax.TaxRate = Decimal.Parse(columns[2]);
            return tax;
        }
    }
}
