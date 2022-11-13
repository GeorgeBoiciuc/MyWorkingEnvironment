using System.ComponentModel.DataAnnotations;

namespace MyWorkingEnvironment.Models
{
    public class MeetingRoomModel
    {
        public Guid IdMeetingRoom { get; set; }
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; } = null!;
    }
}
