//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ohjelmistoprojekti.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Henkilot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Henkilot()
        {
            this.HenkilonOsaamiset = new HashSet<HenkilonOsaamiset>();
        }
    
        public int HenkiloID { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string TyoPuhelin { get; set; }
        public string TyoSahkoposti { get; set; }
        public string Organiaatio { get; set; }
        public Nullable<int> Henkilonumero { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HenkilonOsaamiset> HenkilonOsaamiset { get; set; }
    }
}
