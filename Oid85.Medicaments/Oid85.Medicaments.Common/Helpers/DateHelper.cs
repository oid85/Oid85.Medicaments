namespace Oid85.Medicaments.Common.Helpers;

public static class DateHelper
{
    public static List<DateOnly> GetDates(DateOnly from, DateOnly to)
    {                
        if (from > to)
            return [];

        if (from == to)
            return [from];

        var dates = new List<DateOnly>();

        var curDate = from;

        while (curDate <= to)
        {
            dates.Add(curDate);            
            curDate = curDate.AddDays(1);
        }

        return dates;
    }
}