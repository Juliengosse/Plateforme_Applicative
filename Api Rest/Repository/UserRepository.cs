using Api_Rest.Data;
using Api_Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Rest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                // Utilisation du contexte pour récupérer tous les enregistrements de la table "User" et les convertir en une liste d'objets User
                return _context.Set<User>().ToList();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération des utilisateurs.", ex);
            }
        }

        public User GetById(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver un enregistrement de la table "User" avec l'ID spécifié
                return _context.Set<User>().Find(id);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération de l'utilisateur.", ex);
            }
        }

        public void Add(User user)
        {
            try
            {
                // Utilisation du contexte pour ajouter un nouvel enregistrement dans la table "User"
                _context.Set<User>().Add(user);
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de l'ajout de l'utilisateur.", ex);
            }
        }

        public void Update(User user)
        {
            try
            {
                // Utilisation du contexte pour mettre à jour un enregistrement de la table "User"
                _context.Set<User>().Update(user);
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la mise à jour de l'utilisateur.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver et supprimer un enregistrement de la table "User" avec l'ID spécifié
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Set<User>().Remove(user);
                    // Enregistrement des modifications dans la base de données
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la suppression de l'utilisateur.", ex);
            }
        }

        public async Task<User> GetUserByCredentialsAsync(string username, string password)
        {
            try
            {
                // Utilisation du contexte pour trouver un utilisateur avec les identifiants spécifiés de manière asynchrone
                return await _context.Set<User>().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération de l'utilisateur par ses identifiants.", ex);
            }
        }
    }
}
