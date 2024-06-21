using System;
using System.Linq;

namespace ServiceCore.Utilities
{
    public class DateUtility
    {
        public static DateTime? ConvertFromString(string DateString)
        {
            if (DateString != null)
            {
                var SplittedDateString = DateString.Split("-");
                if (SplittedDateString.Count() == 3)
                {
                    try
                    {
                        var CheckDay = Int32.TryParse(SplittedDateString[0], out var Day);
                        var CheckMonth = Int32.TryParse(SplittedDateString[1], out var Month);
                        var CheckYear = Int32.TryParse(SplittedDateString[2], out var Year);
                        if (CheckDay && CheckMonth && CheckYear)
                        {
                            return new DateTime(Year, Month, Day);
                        }
                    }
                    catch (System.Exception)
                    {

                    }
                }
            }
            return null;
        }
    }
}