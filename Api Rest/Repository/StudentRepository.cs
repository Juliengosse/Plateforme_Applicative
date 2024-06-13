using Api_Rest.Data;
using Api_Rest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api_Rest.Repository
{
    public class StudentRepository : IStudentRepository
    {
        // Déclaration du contexte de base de données
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }

        // Récupération de tous les élèves
        public IEnumerable<Student> GetAll()
        {
            try
            {
                // Utilisation du contexte pour récupérer tous les enregistrements de la table "Student" et les convertir en une liste d'objets Student
                return _context.Set<Student>().ToList();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération des élèves.", ex);
            }
        }

        // Récupération d'un élève par son ID
        public Student GetById(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver un enregistrement de la table "Student" avec l'ID spécifié
                return _context.Set<Student>().Find(id);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération de l'élève.", ex);
            }
        }

        // Ajout d'un élève
        public void Add(Student eleve)
        {
            try
            {
                // Utilisation du contexte pour ajouter un nouvel enregistrement dans la table "Student"
                _context.Set<Student>().Add(eleve);
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de l'ajout de l'élève.", ex);
            }
        }

        // Mise à jour d'un élève
        public void Update(Student eleve)
        {
            try
            {
                // Utilisation du contexte pour mettre à jour un enregistrement de la table "Student"
                _context.Set<Student>().Update(eleve);
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la mise à jour de l'élève.", ex);
            }
        }

        // Suppression d'un élève par son ID
        public void Delete(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver et supprimer un enregistrement de la table "Student" avec l'ID spécifié
                var eleve = _context.Set<Student>().Find(id);
                if (eleve != null)
                {
                    _context.Set<Student>().Remove(eleve);
                    // Enregistrement des modifications dans la base de données
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la suppression de l'élève.", ex);
            }
        }
    }
}
