using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace DataBase
{
    public class Scheduel
    {
        public TimeSpan date { get; set; }
        public int importance { get; set; }
        public int amountOfSubj { get; set; }
        public int previousAmount { get; set; }
         
         

        public List<Scheduel> dataBase = new List<Scheduel>();
        public string path = @"D:\GitHub Repos\SUBD\Scheduel.txt";

        public Scheduel() { }
        public Scheduel(TimeSpan date, int importance, int amountOfSubj, int previousAmount)
        {
            this.date = date;
            this.importance = importance;
            this.amountOfSubj = amountOfSubj;
            this.previousAmount = previousAmount;
            
        }

        

    }
}
