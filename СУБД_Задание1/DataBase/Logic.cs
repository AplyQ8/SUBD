using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace DataBase
{
    public class Logic
    {
        Scheduel scheduel = new Scheduel();

        public void DataCreation()
        {

            FileStream fs = new FileStream(scheduel.path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    string[] array = sr.ReadLine().Split();
                    scheduel.dataBase.Add(new Scheduel(TimeSpan.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3])));
                }

            }
        }
       
        public string Suggestion(int i)
        {
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);
            string answer;
            double coefficient = 1.0;
            if (scheduel.dataBase[i].date > startTime && scheduel.dataBase[i].date < endTime)
            {
                coefficient += 0.1;
            }
            coefficient -= scheduel.dataBase[i].amountOfSubj * 0.1;
            coefficient -= scheduel.dataBase[i].previousAmount * 0.08;
            coefficient += scheduel.dataBase[i].importance * 0.005;
            if (coefficient > 0.6)
                answer = "yes";
            else
                answer = "no";

            return answer;

        }
        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < scheduel.dataBase.Count; i++)
            {
                sb.AppendLine($"{i + 1}: {scheduel.dataBase[i].date}  {scheduel.dataBase[i].amountOfSubj}  {scheduel.dataBase[i].previousAmount}  {scheduel.dataBase[i].importance}");
            }
            return sb.ToString();
        }
    }
}
