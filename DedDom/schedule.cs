//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DedDom
{
    using System;
    using System.Collections.Generic;
    
    public partial class schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public schedule()
        {
            this.visit_log = new HashSet<visit_log>();
        }
    
        public int Id { get; set; }
        public int Id_Subject { get; set; }
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        public Nullable<System.TimeSpan> End_Time { get; set; }
        public int Id_Group { get; set; }
        public int Id_Classroom { get; set; }
        public int Id_Week_Day { get; set; }
    
        public virtual classrom classrom { get; set; }
        public virtual group group { get; set; }
        public virtual subject subject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<visit_log> visit_log { get; set; }
        public virtual week_day week_day { get; set; }
    }
}