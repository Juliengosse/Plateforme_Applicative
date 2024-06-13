namespace Application_web.Models
{
    public class StudentPresence
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime AttendanceDate { get; set; }
    }
}
