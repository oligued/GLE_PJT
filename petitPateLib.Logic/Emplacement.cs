//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace petitPateLib.Logic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emplacement
    {
        public Emplacement()
        {
            this.Cinema = new HashSet<Cinema>();
        }
    
        public int IdPlace { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Cinema> Cinema { get; set; }
    }
}