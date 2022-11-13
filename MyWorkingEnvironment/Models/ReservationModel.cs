using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class ReservationModel
    {
        public Guid IdReservation { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy HH:mm tt}")]
        public DateTime CheckIn { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy HH:mm tt}")]
        public DateTime CheckOut { get; set; }
    }
}
