using System;

namespace EXON.Common
{
    public static class DateTimeHelpers
    {
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            try
            {
                return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
    }
}