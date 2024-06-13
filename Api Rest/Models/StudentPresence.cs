using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Rest.Models
{
    public class StudentPresence
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        //Date de présence
        public DateTime AttendanceDate { get; set; }
    }
}
