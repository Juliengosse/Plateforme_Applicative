using Api_Rest.Data;
using Api_Rest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Api_Rest.Repository
{
    public class GroupRepository : IGroupRepository
    {
        // Déclaration du contexte de base de données
        private readonly Context _context;

        public GroupRepository(Context context)
        {
            _context = context;
        }

        // Récupération de tous les groupes
        public IEnumerable<Group> GetAll()
        {
            try
            {
                // Utilisation du contexte pour récupérer tous les enregistrements de la table "Group" et les convertir en une liste d'objets Group
                return _context.Set<Group>().ToList();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération des groupes.", ex);
            }
        }

        // Récupération d'un groupe par son ID
        public Group GetById(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver un enregistrement de la table "Group" avec l'ID spécifié
                return _context.Set<Group>().Find(id);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la récupération du groupe.", ex);
            }
        }

        // Définition de la méthode asynchrone GetGroupId qui prend trois paramètres de type chaîne (cycle, section, subSection)
        public Task<int?> GetGroupId(string cycle, string section, string subSection)
        {
            try
            {
                // Utilisation d'une connexion SQL avec la chaîne de connexion spécifiée
                using (SqlConnection connection = new SqlConnection("Server=JULIEN\\PR3_PLATAPPLI;Database=PR3 - Plateforme Applicative;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    // Ouverture de la connexion
                    connection.Open();

                    // Définition de la requête SQL avec des paramètres
                    string query = "SELECT ID FROM Groups WHERE Cycle = @cycle AND Section = @section AND subSection = @subSection";

                    // Création d'une commande SQL avec la requête et la connexion
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ajout des paramètres avec leurs valeurs
                        command.Parameters.AddWithValue("@cycle", cycle);
                        command.Parameters.AddWithValue("@section", section);
                        command.Parameters.AddWithValue("@subSection", subSection);

                        // Exécution de la requête et récupération du premier résultat
                        object result = command.ExecuteScalar();

                        // Vérification du résultat
                        if (result != null && result != DBNull.Value)
                        {
                            // Si le résultat est non null, le convertir en entier et le renvoyer dans une tâche asynchrone
                            int groupeId = (int)result;
                            return Task.FromResult<int?>(groupeId);
                        }
                        else
                        {
                            // Si le résultat est null, renvoyer null dans une tâche asynchrone
                            return Task.FromResult<int?>(null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // En cas d'exception, créer une nouvelle exception avec un message d'erreur personnalisé et la lancer
                throw new Exception($"Une erreur s'est produite : {ex.Message}");
            }
        }


        // Ajout d'un groupe
        public void Add(Group group)
        {
            try
            {
                // Utilisation du contexte pour ajouter un nouvel enregistrement dans la table "Group"
                _context.Set<Group>().Add(group);
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de l'ajout du groupe.", ex);
            }
        }

        // Mise à jour d'un groupe
        public void Update(Group group)
        {
            try
            {
                // Utilisation du contexte pour mettre à jour un enregistrement de la table "Group"
                _context.Set<Group>().Update(group);
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la mise à jour du groupe.", ex);
            }
        }

        // Suppression d'un groupe par son ID
        public void Delete(int id)
        {
            try
            {
                // Utilisation du contexte pour trouver et supprimer un enregistrement de la table "Group" avec l'ID spécifié
                var group = _context.Set<Group>().Find(id);
                if (group != null)
                {
                    _context.Set<Group>().Remove(group);
                    // Enregistrement des modifications dans la base de données
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, une exception est levée avec un message d'erreur personnalisé et l'exception d'origine
                throw new Exception("Une erreur s'est produite lors de la suppression du groupe.", ex);
            }
        }

    }
}
