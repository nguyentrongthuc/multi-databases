using System;
using System.Linq;
using System.Collections.Generic;
namespace ServiceCore.Utilities
{
    public class AcademicUtility
    {
        public static bool IsValid(string AcademicString)
        {
            bool check = true;
            if (string.IsNullOrEmpty(AcademicString) || string.IsNullOrWhiteSpace(AcademicString))
            {
                check = false;
            }
            else
            {
                var SplitString = AcademicString.Trim().Split("-");
                if (SplitString.Count() != 2)
                {
                    check = false;
                }
                else
                {
                    var CheckAcademicStartYear = Int32.TryParse(SplitString[0], out var AcademicStartYear);
                    var CheckAcademicEndYear = Int32.TryParse(SplitString[1], out var AcademicEndYear);
                    if (!CheckAcademicStartYear || !CheckAcademicEndYear)
                    {
                        check = false;
                    }
                }
            }
            return check;
        }
        public static string GetCurrentAcademicYearString()
        {
            var MonthTerm2 = new List<int> { 2, 3, 4, 5, 6, 7 };
            var CurrentYear = DateTime.Now.Year;
            var CurrentMonth = DateTime.Now.Month;
            var StartYear = CurrentYear;
            if (MonthTerm2.Contains(CurrentMonth))
            {
                StartYear = CurrentYear - 1;
            }
            return StartYear + "-" + (StartYear + 1);
        }
        public static int GetAcademicStartYear(string AcademicString)
        {
            var SplitString = AcademicString.Trim().Split("-");
            Int32.TryParse(SplitString[0], out var AcademicStartYear);
            return AcademicStartYear;
        }
        public static int GetAcademicEndYear(string AcademicString)
        {
            var SplitString = AcademicString.Trim().Split("-");
            Int32.TryParse(SplitString[1], out var AcademicEndYear);
            return AcademicEndYear;
        }
    }
}