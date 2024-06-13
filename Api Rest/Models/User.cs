using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Rest.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public String Role { get; set; }
    }
}
