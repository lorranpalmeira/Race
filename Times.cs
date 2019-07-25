
using System;

namespace RaceCart
{
    public class Times
    {

        public TimeSpan Hour { get; set; }

        public int Code { get; set; }

        public string Pilot { get; set; }

        public int Lap { get; set; }

        public TimeSpan Time { get; set; }

        public double BestTurn { get; set; }

        public override bool Equals(Object obj)
        {           
            if(obj is Times)
            {
                Times times = obj as Times;
                if(times.Pilot == this.Pilot)
                    return true;
                return false;
            }

            return false;
        }
    }


}