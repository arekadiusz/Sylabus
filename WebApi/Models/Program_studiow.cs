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
    
    public partial class Program_studiow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program_studiow()
        {
            this.Siatka_godzin = new HashSet<Siatka_godzin>();
        }
    
        public string Id_programu { get; set; }
        public string Kod_przedmiotu { get; set; }
        public string Wydzial { get; set; }
        public string Tryb_studiow { get; set; }
        public string Stopien_studiow { get; set; }
        public string Nazwa_PL { get; set; }
        public string Nazwa_ENG { get; set; }
        public string Tutul_zawodowy { get; set; }
    
        public virtual Wydzial Wydzial1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siatka_godzin> Siatka_godzin { get; set; }
    }
}