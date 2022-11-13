using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class ClockingModel
    {
        public Guid IdClocking { get; set; }
        public Guid IdEmployee { get; set; }
        public string Type { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy HH:mm tt}")]
        public DateTime CheckIn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy HH:mm tt}")]
        public DateTime CheckOut { get; set; }
    }

    public enum ClockingType
    {
        Workday,
        Vacation,
        NationalHoliday,
        Sickleave
    }
}
