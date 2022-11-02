namespace MyWorkingEnvironment.Models
{
    public class ReservationModel
    {
        public Guid IdReservation { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
