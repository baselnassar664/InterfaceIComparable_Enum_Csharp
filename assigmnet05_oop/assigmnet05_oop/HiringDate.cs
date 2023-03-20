using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigmnet05_oop
{
    internal class HiringDate
    {
        int day, month, year;

      

        public int Day { get { return day; } set { day = value >= 1 && value <= 31 ? value : 1; } }
        public int Month { get { return month; } set { month = value >= 1 && value <= 12 ? value : 1; } }
        public int Year { get { return year; } set { year = value >= 1 && value < 31 ? value : 1; } }

          public HiringDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public override string ToString()
        {
            return $"{day}/{month}/{year}";
        }

    }
}
