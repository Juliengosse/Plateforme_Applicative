using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_desktop.Models
{
    internal class Student
    {
        public int Id { get; set; }

        //Nom de l'élève
        public string Name { get; set; }

        //Prénom de l'élève
        public string Firstname { get; set; }

        //Group de l'élève
        public int GroupId { get; set; }

        public Student() { }

        public Student(int id, string name, string firstname, int groupId)
        {
            Id = id;
            Name = name;
            Firstname = firstname;
            GroupId = groupId;
        }

        public Student(string name, string firstname, int groupId)
        {
            Name = name;
            Firstname = firstname;
            GroupId = groupId;
        }
    }
}
