using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Rest.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
    }
}
