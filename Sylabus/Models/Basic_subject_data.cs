//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sylabus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Basic_subject_data
    {
        public string Subject_code { get; set; }
        public int Lecture_hours { get; set; }
        public int Exercise_hours { get; set; }
        public int Laboratories_hours { get; set; }
        public int Own_work { get; set; }
        public int Ects { get; set; }
        public bool Exam { get; set; }
        public string Name_PL { get; set; }
    
        public virtual Sylabus Sylabus { get; set; }
    }
}
