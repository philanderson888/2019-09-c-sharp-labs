using System;

namespace labs_just_do_it_17_enum_with_tests
{
    class Program
    {
        static void Main(string[] args)
        {
     
        }
    }

    public enum DaysOfWeek
    {
        Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday
    }
    public enum MonthsOfYear
    {
        January=1,February,March,April,May,June,July,August,
        September,October,November,December
    }

    public class TestEnums
    {
        public static (string,string)GetDayMonth(int day, int month)
        {
            var dayofweek = Enum.GetName(typeof(DaysOfWeek), day);
            var monthsofyear = Enum.GetName(typeof(MonthsOfYear), month);

            return (dayofweek,monthsofyear); // TUPLE IS CUSTOM ANONYMOUS 
                                       // DATA TYPE IE WITHOUT A NAME
        }
    }
}
