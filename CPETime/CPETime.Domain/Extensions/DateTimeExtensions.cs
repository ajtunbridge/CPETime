#region Using directives

using System;

#endregion

// ReSharper disable CheckNamespace
public static class DateTimeExtensions
// ReSharper restore CheckNamespace
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = dt.DayOfWeek - startOfWeek;

        if (diff < 0)
        {
            diff += 7;
        }

        return dt.AddDays(-1 * diff).Date;
    }
}