//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Elementy_template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elementy_template()
        {
            this.Wartosc_Elementu = new HashSet<Wartosc_Elementu>();
        }
    
        public int Id { get; set; }
        public string Nazwa_elementu { get; set; }
        public string Tempalate { get; set; }
        public string Sylabus { get; set; }
        public string Obowiazkowy { get; set; }
        public string Kolejność { get; set; }
        public string Typ_tabeli { get; set; }
    
        public virtual Template Template { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wartosc_Elementu> Wartosc_Elementu { get; set; }
    }
}
