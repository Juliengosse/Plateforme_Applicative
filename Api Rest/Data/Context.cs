using Api_Rest.Models;
using Api_Rest.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api_Rest.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // Définir les propriétés DbSet pour les entités de votre modèle de données
        // DbSet<T> est utilisé pour interagir avec ces enregistrements dans une base de données relationnelle.

        /*Voici quelques exemples d'opérations que vous pouvez effectuer avec DbSet<T>:

        DbSet<T>.Add(entity) : Ajoute un nouvel enregistrement à la base de données pour l'entité spécifiée.
        DbSet<T>.Find(keyValues) : Récupère un enregistrement de la base de données en fonction de la clé primaire spécifiée.
        DbSet<T>.ToList() : Récupère tous les enregistrements de la base de données pour l'entité spécifiée et les retourne sous forme de liste.
        DbSet<T>.Remove(entity) : Supprime un enregistrement de la base de données pour l'entité spécifiée.*/

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentPresence> StudentPresences { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
