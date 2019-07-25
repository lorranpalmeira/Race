using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceCart
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            var timeList = new List<Times>();

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"./cart.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] columns = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                timeList.Add(
                    new Times
                    {
                        Hour = TimeSpan.Parse(columns[0]),
                        Code = Convert.ToInt32(columns[1]),
                        Pilot = columns[3],
                        Lap = Convert.ToInt32(columns[4]),
                        Time = TimeSpan.Parse("00:" + columns[5]),
                        BestTurn = Convert.ToDouble(columns[6])
                    }
                );
            }

            file.Close();

            var ordered = timeList.Where(x => x.Lap > 3).OrderBy(x => x.Hour);

            foreach (var item in ordered)
            {
                item.Time = TimeSpan.Zero;
               foreach (var geral in timeList)
               {
                   if(geral.Pilot == item.Pilot)
                   {
                       item.Time += geral.Time; 
                   }
               }
            }

            int position = 1;
            foreach (var item in ordered)
            {
                Console.WriteLine($"Posição Chegada: {position} - Código Piloto : {item.Code} - "+
                        $"Piloto: {item.Pilot} - Voltas: {item.Lap } - Tempo de Prova: { item.Time }");
                position++;
            }

        }
    }
}
