using System.ComponentModel.DataAnnotations;

namespace Api_Rest.Models
{
    public class Group
    {
        [Required]
        public int Id { get; set; }

        /**
        * Cycle d'étude: Ingénieur, Bachelor, Master, Prépa
        */
        public string Cycle { get; set; }

        /**
        * Section (année d'étude): I1, I2, I3, ERIS1, ERIS2, MS2D1, ...
        */
        public string Section { get; set; }

        /**
        * Sous-section : FA(formation alternant) / FE(formation étudiant)
        */
        public string SubSection { get; set; }
    }
}
