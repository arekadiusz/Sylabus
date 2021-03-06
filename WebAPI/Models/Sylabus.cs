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
    
    public partial class Sylabus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sylabus()
        {
            this.Elements_value = new HashSet<Elements_value>();
            this.Ours_grid_elements = new HashSet<Ours_grid_elements>();
        }
    
        public string Id_sylabus { get; set; }
        public string Subject_code { get; set; }
        public string Template { get; set; }
        public string Ours_grid { get; set; }
        public string Lecturer { get; set; }
        public string Basic_data { get; set; }
        public Nullable<int> Faculty { get; set; }
    
        public virtual Basic_subject_data Basic_subject_data { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elements_value> Elements_value { get; set; }
        public virtual Faculty Faculty1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ours_grid_elements> Ours_grid_elements { get; set; }
        public virtual Template Template1 { get; set; }
        public virtual Users Users { get; set; }
    }
}
