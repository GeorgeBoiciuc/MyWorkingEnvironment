using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class ClockingModel
    {
        public Guid IdClocking { get; set; }
        public Guid? IdEmployee { get; set; }
        public string Type { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime In { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime Out { get; set; }
    }

    public enum ClockingType
    {
        Workday,
        Vacation,
        NationalHoliday,
        Sickleave
    }
}
