using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVLT.DTOs
{
    public class DateDTO
    {
        public DateDTO() { }
        public DateDTO(DateTime pDate)
        {
            Year= pDate.Year;
            Month= pDate.Month;
            Day = pDate.Day;
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime ToDateTime() {
            return new DateTime(Year,Month,Day);
        }
    }
    public static class DateExt {
     public static DateDTO GetDateDTO(this DateTime date)
        {
            return new DateDTO(date);
        } 
    }
}
