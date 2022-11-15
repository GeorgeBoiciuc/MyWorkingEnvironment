namespace MyWorkingEnvironment.Models
{
    public class MeetingRoomModel
    {
        public Guid IdMeetingRoom { get; set; }
        public string Name { get; set; } = null!;
        public string? Floor { get; set; }
        public int? Capacity { get; set; }
    }
}
