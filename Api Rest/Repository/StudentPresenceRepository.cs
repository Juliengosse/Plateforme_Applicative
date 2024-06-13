using Api_Rest.Data;
using Api_Rest.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Api_Rest.Repository
{
    public class StudentPresenceRepository : IStudentPresenceRepository
    {
        // Déclaration du contexte de base de données
        private readonly Context _context;

        public StudentPresenceRepository(Context context)
        {
            _context = context;
        }

        // Récupération de toutes les présences d'élèves
        public IEnumerable<StudentPresence> GetAll()
        {
            try
            {
                // Utilisation du contexte pour récupérer tous les enregistrements de la table "StudentPresence" et les convertir en une liste d'objets StudentPresence
                return _context.Set<StudentPresence>().ToList();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération des présences.", ex);
            }
        }

        // Récupération d'une présence d'élève par son ID
        public StudentPresence GetById(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver un enregistrement de la table "StudentPresence" avec l'ID spécifié
                return _context.Set<StudentPresence>().Find(id);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération de la présence.", ex);
            }
        }

        // Ajout d'une présence d'élève
        public void Add(StudentPresence studentPresence)
        {
            try
            {
                // Utilisation du contexte pour ajouter un nouvel enregistrement dans la table "StudentPresence"
                _context.Set<StudentPresence>().Add(studentPresence);

                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de l'ajout de la présence.", ex);
            }
        }

        // Mise à jour d'une présence d'élève
        public void Update(StudentPresence studentPresence)
        {
            try
            {
                // Utilisation du contexte pour mettre à jour un enregistrement de la table "StudentPresence"
                _context.Set<StudentPresence>().Update(studentPresence);

                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la mise à jour de la présence.", ex);
            }
        }

        // Suppression d'une présence d'élève par son ID
        public void Delete(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver et supprimer un enregistrement de la table "StudentPresence" avec l'ID spécifié
                var studentPresence = _context.Set<StudentPresence>().Find(id);
                if (studentPresence != null)
                {
                    _context.Set<StudentPresence>().Remove(studentPresence);

                    // Enregistrement des modifications dans la base de données
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la suppression de la présence.", ex);
            }
        }
    }
}
