//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PojectGANkurs
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rasp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rasp()
        {
            this.Registr = new HashSet<Registr>();
        }
    
        public int idrasp { get; set; }
        public int iddoc { get; set; }
        public System.TimeSpan Timestart { get; set; }
        public System.TimeSpan Timeend { get; set; }
        public string weekday { get; set; }
        public string day { get; set; }
    
        public virtual Doctors Doctors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registr> Registr { get; set; }
    }
}