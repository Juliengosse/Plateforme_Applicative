using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_desktop.Models
{
    internal class Group
    {
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

        public Group() { }

        public Group(int id, string cycle, string section, string subSection)
        {
            Id = id;
            Cycle = cycle;
            Section = section;
            SubSection = subSection;
        }

        public Group(string cycle, string section, string subSection) 
        { 
            Cycle = cycle;
            Section = section;
            SubSection = subSection;
        }
    }
}
