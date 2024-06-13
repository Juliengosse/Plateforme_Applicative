using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_desktop.Models
{
    internal class StudentPresence
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime AttendanceDate { get; set; }
    }
}
