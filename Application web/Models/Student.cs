namespace Application_web.Models
{
    public class Student
    {
        public int Id { get; set; }

        //Nom de l'élève
        public string Name { get; set; }

        //Prénom de l'élève
        public string Firstname { get; set; }

        //Group de l'élève
        public int GroupId { get; set; }
    }
}
