namespace MyWorkingEnvironment.Models
{
    public class ClockingModel
    {
        public Guid IdClocking { get; set; }
        public Guid IdEmployee { get; set; }
        public string Type { get; set; } = null!;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
