//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uzytkownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uzytkownicy()
        {
            this.Sylabus = new HashSet<Sylabu>();
        }
    
        public Nullable<int> Id { get; set; }
        public int E_mail { get; set; }
        public string Rola { get; set; }
        public string Wydzial { get; set; }
    
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sylabu> Sylabus { get; set; }
        public virtual Wydzial Wydzial1 { get; set; }
    }
}
