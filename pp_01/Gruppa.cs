//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pp_01
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gruppa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gruppa()
        {
            this.Obuchau = new HashSet<Obuchau>();
            this.Raspicanie = new HashSet<Raspicanie>();
        }
    
        public int id_gruppa { get; set; }
        public string name_gruppa { get; set; }
        public string svedeniy { get; set; }
        public Nullable<int> id_trener { get; set; }
    
        public virtual Trener Trener { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obuchau> Obuchau { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raspicanie> Raspicanie { get; set; }
    }
}
