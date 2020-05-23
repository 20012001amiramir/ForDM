using CsvHelper;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ForDataMining2
{
    public class ProgrammingLanguage
    {
        [Name("BASKET_ID")]
        public long Basket { get; set; }
        [Name("PROD_CODE")]
        public string Product { get; set; }
    }

    public class Basket
    {
        public int[] count;
        public string[] names;
        public string NameBasket;

        Basket(int[] Count,string[] namepr, string name)
        {
            this.count = Count;
            this.names = namepr;
            this.NameBasket = name;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            string pathCsvFile = "transactions.csv";
                using (CsvReader csvReader = new CsvHelper.CsvReader(new StreamReader(pathCsvFile)))
                {
                    // указываем используемый разделитель
                    csvReader.Configuration.Delimiter = ";";
                    // получаем строки     
                    IEnumerable programmingLanguages =
                        csvReader.GetRecords<ProgrammingLanguage>();
                    var asd = programmingLanguages.Cast<ProgrammingLanguage>();
                    List<long> Baskets = new List<long>();
                    List<string> Produckts = new List<string>();
                    foreach (var a in asd)
                    {
                        Baskets.Add(a.Basket);
                        Produckts.Add(a.Product);
                    }
                    List<Basket> prodlist = new List<Basket>();
                    
                    foreach (var a in Baskets)
                    {
                        
                    }
                }
            
        }
    }
}